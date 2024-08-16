using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curar : MonoBehaviour
{
    public int curacion;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Vidas vidas))
        {
            vidas.CurarVida(curacion);
        }

        if (other.gameObject.tag == "Player")
        {
            //soundManager.SoundEffect();
            //Agarrar_moneda.agarrar();
            Destroy(gameObject);
        }
    }
}
