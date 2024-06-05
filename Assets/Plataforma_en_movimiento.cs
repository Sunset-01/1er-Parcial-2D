using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_en_movimiento : MonoBehaviour
{
    public GameObject ObjetoAmover;

    public Transform PuntoPartida;
    public Transform PuntoFinal;

    public float Velocidad;

    private Vector3 MoverHacia;

    void Start()
    {
        MoverHacia = PuntoFinal.position;
    }

    void Update()
    {
        ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, MoverHacia, Velocidad * Time.deltaTime);

        if(ObjetoAmover.transform.position == PuntoFinal.position)
        {
            MoverHacia = PuntoPartida.position;
        }
        if (ObjetoAmover.transform.position == PuntoPartida.position)
        {
            MoverHacia = PuntoFinal.position;
        }
    }
}
