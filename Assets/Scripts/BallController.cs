using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] PaddleController paddle;
    [SerializeField] float startSpeed;
    // Start is called before the first frame update

    bool isGrounded = true;
    Rigidbody2D rb;
    Vector2 paddleToBallVector;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            rb.position = new Vector2(paddle.GetPosition().x, paddle.GetStartY() + paddle.transform.position.y);
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                isGrounded = false;
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    public void groundBall()
    {
        isGrounded = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    private void throwBall()
    {
        isGrounded = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = new Vector2(0f, 15f);
    }
}
