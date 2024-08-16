using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            soundManager.SoundEffect();
            Agarrar_moneda.agarrar();
            Destroy(gameObject);
        }


    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Player") 
    //    {
    //        other.gameObject.GetComponent<Agarrar_moneda>().agarrar();
    //        audioSource.Play();
    //        Destroy(gameObject);
    //    }
    //}
}
