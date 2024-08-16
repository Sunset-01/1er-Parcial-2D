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
    //        tomarDa�o(valorPrueba);
    //    }
    //    if (Input.GetButtonDown("Fire2"))
    //    {
    //        CurarVida(valorPrueba);
    //    }
    //}

    public void tomarDa�o(int cantidadDa�o)
    {
        int vidaTemporal = vidaActual - cantidadDa�o;

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
