using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public int daño;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Vidas vidas)) 
        {
            vidas.tomarDaño(daño);
        }
    }
}
