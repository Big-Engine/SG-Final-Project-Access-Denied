using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation_Handler : MonoBehaviour
{
    [SerializeField] Animator playerAnimator = null;

    private bool isGrounded = false;

    private RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical") > 0)
        {
            isGrounded = false;
        }

        if (isGrounded)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (Input.GetMouseButton(0))
                {
                    playerAnimator.Play("PlayerRunning_Shooting");
                }
                else
                {
                    playerAnimator.Play("PlayerRunning");
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    playerAnimator.Play("PlayerIdle_Shooting");
                }
                else
                {
                    playerAnimator.Play("PlayerIdle");
                }
            }
        }
        else
        {
            playerAnimator.Play("PlayerJump");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }
}
