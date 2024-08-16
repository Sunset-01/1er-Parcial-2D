using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;



public class Dasheando : MonoBehaviour
{
    private float speed = 8f;
    private float runningSpeed = 30f; 

    //private bool isFacingRight = true;

    private bool CanDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float DashingCooldown = 1f;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private TrailRenderer tr;



    private void Update()
    {




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



        if (Input.GetKeyDown(KeyCode.LeftShift) && CanDash)
        {
            StartCoroutine(Dash());
        }

    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        Vector2 x = rb.velocity;
        x.x += speed * InputManager.moveplayer().x * Time.deltaTime;
        rb.velocity = x;
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



