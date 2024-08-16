using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarNivel : MonoBehaviour
{
    [SerializeField] private GameObject MenuDeAjustes;
    public void EncenderMenuAjustes()
    {
        MenuDeAjustes.SetActive(true);
    }

    public void ApagarMenuAjustes()
    {
        MenuDeAjustes.SetActive(false);
    }

        public void CambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
        Time.timeScale = 1f;
    }



    //public void continuars()
    //{
    //    Time.timeScale = 1f;
        
    //}
}

