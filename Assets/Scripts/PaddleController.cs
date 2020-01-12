using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] float maxScreenUnit = 16f;
    [SerializeField] BallController ball = null;

    private Rigidbody2D rb;
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            float posX = Mathf.Clamp(rb.position.x + Input.GetAxis("Mouse X"), 1f, maxScreenUnit - 1f);
            rb.MovePosition(new Vector2(posX, transform.position.y));
        }
        if (ball.IsGrounded())
        {
            ball.transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                ball.ThrowBall();
            }
        }
        
    }

    public Vector2 GetPosition()
    {
        return rb.position;
    }

    public float GetStartY()
    {
        return GetComponentInChildren<Transform>().position.y;
    }
}
