//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class WinCon : MonoBehaviour
//{
//    private bool isPaused = false;

//    void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            // Alternar estado de pausa.
//            isPaused = !isPaused;
//            TogglePause();
//        }
//    }

//    void TogglePause()
//    {
//        if (isPaused)
//        {
//            Time.timeScale = 0; // Pausar el juego.
//            // Aquí puedes mostrar un panel de pausa, mensaje, etc.
//            Debug.Log("Juego Pausado");
//        }
//        else
//        {
//            Time.timeScale = 1; // Reanudar el juego.
//            // Aquí puedes ocultar el panel de pausa, mensaje, etc.
//            Debug.Log("Juego Reanudado");
//        }
//    }
//}


