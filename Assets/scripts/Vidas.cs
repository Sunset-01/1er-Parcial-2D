using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class Vidas : MonoBehaviour
{
    public int vidaActual;
    public int vidaMaxima;
    public UnityEvent<int> cambioVida;
    //public event EventHandler MuerteJugador;
    //public int valorPrueba;


    private void Start()
    {
        vidaActual = vidaMaxima;
        cambioVida.Invoke(vidaActual);
    }

    //private void Update()
    //{
    //    if (Input.GetButtonDown("Fire1") )
    //    {
    //        tomarDaño(valorPrueba);
    //    }
    //    if (Input.GetButtonDown("Fire2"))
    //    {
    //        CurarVida(valorPrueba);
    //    }
    //}

    public void tomarDaño(int cantidadDaño)
    {
        int vidaTemporal = vidaActual - cantidadDaño;

        if (vidaTemporal < 0)
        {
            vidaActual = 0;
        }

        else
        {
            vidaActual = vidaTemporal;
        }

        cambioVida.Invoke(vidaActual);

        if (vidaTemporal <= 0) 
        { 
            //MuerteJugador?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
            print("FIN");
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }

    public void CurarVida (int CantidadCuracion)
    {
        int vidaTemporal = vidaActual + CantidadCuracion;

        if (vidaTemporal > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
        else
        {
            vidaActual = vidaTemporal;
        }

        cambioVida.Invoke(vidaActual);
    }
}
