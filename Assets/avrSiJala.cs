using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class avrSiJala : MonoBehaviour
{
    public GameObject pausePanel; // Asocia el panel de pausa en el Inspector.

    private bool isPaused = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPaused = !isPaused;
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 0; // Pausar el juego.
            if (pausePanel != null)
            {
                pausePanel.SetActive(true); // Mostrar el panel de pausa.
            }
            Debug.Log("Juego Pausado");
        }
        else
        {
            Time.timeScale = 1; // Reanudar el juego.
            if (pausePanel != null)
            {
                pausePanel.SetActive(false); // Ocultar el panel de pausa.
            }
            Debug.Log("Juego Reanudado");
        }
    }
}

    //private bool isPaused = false;

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        // Alternar estado de pausa.
    //        isPaused = !isPaused;
    //        TogglePause();
    //    }
    //}

    //void TogglePause()
    //{
    //    if (isPaused)
    //    {
    //        Time.timeScale = 0; // Pausar el juego.
    //        // Aquí puedes mostrar un panel de pausa, mensaje, etc.
    //        Debug.Log("Juego Pausado");
    //    }
    //    else
    //    {
    //        Time.timeScale = 1; // Reanudar el juego.
    //        // Aquí puedes ocultar el panel de pausa, mensaje, etc.
    //        Debug.Log("Juego Reanudado");
    //    }
    //}

