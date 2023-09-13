using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isDead;
    public bool IsDead { get { return isDead; } }

    private bool isGrounded = false;

    private int jumpCount = 0;

    public float jumpForce = 300f;

    private Animator anim;
    private Rigidbody2D rb2d;
    private AudioSource audioSource;

    public AudioClip dieAudioClip;


    private void Awake()
    {
        Debug.Log("Player Awake");
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        audioSource= GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Debug.Log("Player OnEnable");

    }

    // Update is called once per frame
    void Update()
    {        
        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            ++jumpCount;
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * jumpForce);
            audioSource.Play();
        }

        if(Input.GetMouseButtonUp(0) && rb2d.velocity.y > 0)
        {
            rb2d.velocity = rb2d.velocity * 0.5f;
        }

        anim.SetBool("Grounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            if (collision.contacts[0].normal.y > 0.7f)
            {
                GameManager.Instance.AddScore(1);
                isGrounded = true;
                jumpCount = 0;
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dead") && !isDead)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        anim.SetTrigger("Die");
        rb2d.velocity = Vector2.zero;

        audioSource.clip = dieAudioClip;
        audioSource.Play();

        GameManager.Instance.OnPlayerDead();
    }
}
