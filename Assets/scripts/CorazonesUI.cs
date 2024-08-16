using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CorazonesUI : MonoBehaviour
{
    public List<Image> listaCorazones;
    public GameObject corazónPrefab;
    public Vidas vidas;
    public int indexActual;
    public Sprite corazonlleno;
    public Sprite corazonVacio;

    private void Awake()
    {
        vidas.cambioVida.AddListener(CambiarCorazones);

    }

    private void CambiarCorazones(int vidaActual)
    {
        if (!listaCorazones.Any()) 
        {
            CrearCorazones(vidaActual);
        }
        else
        {
            CambiarVida(vidaActual);
        }


    }
    private void CrearCorazones(int CantidadMaximaVida)
    {
        for (int i = 0; i < CantidadMaximaVida; i++) 
        {
            GameObject corazon = Instantiate(corazónPrefab, transform);

            listaCorazones.Add(corazon.GetComponent<Image>());
        }

        indexActual = CantidadMaximaVida - 1;
    }

    private void CambiarVida(int vidaActual)
    {
        if (vidaActual <= indexActual)
        {
            QuitarCorazones(vidaActual);
        }
        else
        {
            AgregarCorazones(vidaActual);
        }
    }
    private void QuitarCorazones(int vidaActual)
    { 
        for (int i = indexActual; i >= vidaActual; i--)
        {
            indexActual = i;
            listaCorazones[indexActual].sprite = corazonVacio;

        }
    }
    private void AgregarCorazones(int vidaActual)
    {
        for (int i = indexActual; i < vidaActual; i++)
        {
            indexActual = i;
            listaCorazones[indexActual].sprite = corazonlleno;

        }
    }


}
