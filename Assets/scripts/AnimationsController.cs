using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    private Rigidbody2D Rv;
    private Animator animator;


    void Start()
    {
        Rv = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    { 
        if (Rv.velocity.x != 0 && Rv.velocity.y == 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Run", true);
            animator.SetBool("Jump", false);
            animator.SetBool("Caída", false);       
        }
        if (Rv.velocity.y > 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Run", false);
            animator.SetBool("Jump", true);
            animator.SetBool("Caída", false);
        }
        if (Rv.velocity.y < 0)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Run", false);
            animator.SetBool("Jump", false);
            animator.SetBool("Caída", true);
        }
        if (Rv.velocity.y == 0 && Rv.velocity.x == 0)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Run", false);
            animator.SetBool("Jump", false);
            animator.SetBool("Caída", false);
        }

        //else
        //{
        //    animator.SetBool("Run", false);

        //    animator.SetBool("Idle", true);
        //}
    }
}
