using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AAAAAAAA : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private float Horizontal;
    private Rigidbody2D Rigidbody2D;
    private int jumpsLeft; 
    private bool isGrounded; 
    private Animator animator; 

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        jumpsLeft = 2; 
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        
        animator.SetFloat("Speed", Mathf.Abs(Horizontal));

        if (Input.GetKeyDown(KeyCode.W) && jumpsLeft > 0)
        {
            Jump();
            jumpsLeft--; 
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);

        animator.SetTrigger("Jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsLeft = 2; 
            isGrounded = true;
            animator.SetBool("Grounded", true); 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("Grounded", false); 
        }
    }
}


