using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRB;

    [SerializeField] float speed; // 10 works well
    [SerializeField] float jumpForce; // should be above 200

    [SerializeField] float horizontalDrag; // 5 works well

    private bool isGrounded = false;
    private bool isMoving = false;

    void Start()
    {
        isGrounded = false;
    }

    void Update()
    {
        Debug.Log(isGrounded);
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            isMoving = true;
            ToggleHorizontalDrag(0);
            Move();
        }
        else
        {
            isMoving = false;
            ToggleHorizontalDrag(horizontalDrag);
        }

        if (isGrounded)
        {
            if(Input.GetAxisRaw("Vertical") > 0)
            {
                Jump(isMoving);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = false;
        }
    }

    private void ToggleHorizontalDrag(float drag)
    {
        playerRB.drag = drag;
    }

    private void Move()
    {
        playerRB.AddForce(new Vector2(Input.GetAxisRaw("Horizontal"), 0) * speed);
    }

    private void Jump(bool isMoving)
    {
        if (!isMoving)
        {
            playerRB.AddForce(new Vector2(0, 1) * jumpForce);
        }
        else
        {
            playerRB.AddForce(new Vector2(0, .5f) * jumpForce);
        }
    }
}
