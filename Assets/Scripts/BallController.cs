using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float startSpeed = 5f;
    [SerializeField] float maxSpeed = 15f;

    [SerializeField] AudioClip[] clips;
    // Start is called before the first frame update

    bool isGrounded = true;
    Rigidbody2D rb;
    AudioSource audioSource;
    void Start()
    {
        isGrounded = true;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGrounded)
        {
            audioSource.PlayOneShot(clips[0]);
        }

    }

    public void GroundBall()
    {
        isGrounded = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void ThrowBall()
    {
        isGrounded = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = new Vector2(0f, startSpeed);
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    public void BlockDestroied()
    {
        audioSource.PlayOneShot(clips[1]);
    }
    
}
