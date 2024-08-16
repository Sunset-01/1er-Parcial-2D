using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarJuego : MonoBehaviour
{
    public void QuitarJuego()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
