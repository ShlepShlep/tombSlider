using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject landParticles;
    public float speed = 8;
    Rigidbody2D rb;
    Vector2 input = Vector2.left;
    public bool canDash;
    public LayerMask wallLayer;
    public GameObject coin;
    public AudioSource audio;
    public AudioClip clip;
    private bool isMoving = false;
    public bool hasLanded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var newInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (rb.velocity.magnitude < 0.1f && newInput != Vector2.zero)
        {
            input = newInput;
            transform.up = -input;
        }

        rb.velocity = speed * input;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            audio.clip = clip;
            audio.Play();
            
            Destroy(collision.gameObject);
        }
    }


}
