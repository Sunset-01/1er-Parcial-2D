//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NewBehaviourScript : MonoBehaviour
//{
//    public float FuerzaSalto;

//    //private float Horizontal;
//    private Rigidbody2D rb;
//    private Animator animator;
//    // Start is called before the first frame update
//    void Start()
//    {
//        animator = GetComponent<Animator>();
//        rb = GetComponent<Rigidbody2D>();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        //Horizontal = Input.GetAxisRaw("Horizontal");

//        if (Input.GetKeyDown(KeyCode.W))
//        {
//            animator.SetBool("EstaSaltando", true);
//            rb.AddForce(new Vector2(0, FuerzaSalto));
//        }
//    }

//    //private void FixedUpdate()
//    //{
//    //    Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
//    //}

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.tag == "Suelo")
//        {
//            animator.SetBool("EstaSaltando", false);
//        }
//    }
//}
