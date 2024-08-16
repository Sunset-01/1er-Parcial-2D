using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugadore : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bala;
    [SerializeField] private float tiempoEntreDisparos = 0.5f; // Tiempo de espera entre disparos en segundos

    private float tiempoUltimoDisparo;

    private void Update()
    {
        if (InputManager.Shuut()) /*(Input.GetButtonDown("Fire1"))*/
        {
            if (Time.time - tiempoUltimoDisparo >= tiempoEntreDisparos)
            {
                Disparar();
                tiempoUltimoDisparo = Time.time; // Actualizar el tiempo del último disparo
            }
        }
    }

    private void Disparar()
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DisparoJugadore : MonoBehaviour
//{
//    [SerializeField] private Transform controladorDisparo;
//    [SerializeField] private GameObject bala;

//    private void Update()
//    {
//        if (InputManager.Shuut()) /*(Input.GetButtonDown("Fire1"))*/
//        {
//            Disparar();
//        }
//    }

//    private void Disparar() 
//    {
//        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);

//    }


//}