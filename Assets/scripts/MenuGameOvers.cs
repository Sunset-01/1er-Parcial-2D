//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using System;


//public class MenuGameOvers : MonoBehaviour
//{
//    [SerializeField] private GameObject menuGameOver;
//    private Vidas vidas;
//    private void Start()
//    {
//        vidas = GameObject.FindGameObjectWithTag("Player").GetComponent<Vidas>();
//        vidas.MuerteJugador += ActivarMenu;
//    }

//    private void ActivarMenu(object sender , EventArgs e)
//    {
//        menuGameOver.SetActive(true);
//    }

    
//    public void Reiniciar()
//    {
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//    }

//    public void MenuInicial(string nombre)
//    {
//        SceneManager.LoadScene(nombre);
//    }

//    public void Salir()
//    {
//        UnityEditor.EditorApplication.isPlaying = false;
//        Application.Quit();
//    }
//}
