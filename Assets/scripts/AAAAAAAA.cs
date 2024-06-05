using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAAAAAAA : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private float Horizontal;
    private Rigidbody2D Rigidbody2D;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W)) 
        {
            Jump();
        }
    }

    private void Jump() 
    { 
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
}
