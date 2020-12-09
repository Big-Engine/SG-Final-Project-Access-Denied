using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRB = null;
    [SerializeField] SpriteRenderer spriteRenderer = null;

    // Player Rigidbidy gravity should be more than 3, adjust variables below accordingly

    [SerializeField] float speed = 0; // 22 works well
    [SerializeField] float jumpForce = 0; // should be above 600

    [SerializeField] float horizontalDrag = 0; // 5 works well

    [SerializeField] private bool isGrounded = false;
    private bool isMoving = false;

    public AudioSource jumpSoundFX;

    void Start()
    {
        isGrounded = false;
    }

    void Update()
    {
        FlipSprite();
    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            isMoving = true;
            ToggleHorizontalDrag(horizontalDrag/2);
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
                jumpSoundFX.Play();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
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
            playerRB.AddForce(new Vector2(0, .75f) * jumpForce);
        }
    }

    private void FlipSprite()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = false;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX = true;
        }
    }
}
