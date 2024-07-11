using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;



public class Dasheando : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float runningSpeed = 30f; 
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    private bool CanDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float DashingCooldown = 1f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    [Header("Animacion")]
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

    }

    private void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));


        if (isDashing)
        {
            return;
        }



        if (Input.GetKey(KeyCode.T)) 
        {
            speed = runningSpeed;
        }
        else
        {
            speed = 8f; 
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && CanDash)
        {
            StartCoroutine(Dash());
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localscale = transform.localScale;
            isFacingRight = !isFacingRight;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }

    private IEnumerator Dash()
    {
        CanDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(DashingCooldown);
        CanDash = true;
    }
}



