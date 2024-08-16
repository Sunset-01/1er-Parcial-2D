using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Agarrar_moneda : MonoBehaviour
{
    public Text puntos;
    public static int monedas;

    void Start()
    {
        
    }

    void Update()
    {
        puntos.text = monedas.ToString();
    }

    public static void agarrar()
    {
        monedas += 1;
    }
}
