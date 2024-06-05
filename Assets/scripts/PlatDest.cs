using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float SaltarFuerza = 3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemigo"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * SaltarFuerza);
        }
    }

}
