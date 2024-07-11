using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraDeadzone : MonoBehaviour
{
    public float deadzoneSize = .5f;


    public GameObject jugador; 

    private new Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Vector3 playerPosition = camera.WorldToViewportPoint(jugador.transform.position);

        if (playerPosition.x < deadzoneSize)
        {
            // El jugador está en la zona muerta izquierda
            camera.orthographicSize *= (1 - deadzoneSize) / (1 - playerPosition.x);
        }
        else if (playerPosition.x > 1 - deadzoneSize)
        {
            // El jugador está en la zona muerta derecha
            camera.orthographicSize *= (1 - deadzoneSize) / (playerPosition.x - (1 - deadzoneSize));
        }

        if (playerPosition.y < deadzoneSize)
        {
            // El jugador está en la zona muerta inferior
            camera.orthographicSize *= (1 - deadzoneSize) / (1 - playerPosition.y);
        }
        else if (playerPosition.y > 1 - deadzoneSize)
        {
            // El jugador está en la zona muerta superior
            camera.orthographicSize *= (1 - deadzoneSize) / (playerPosition.y - (1 - deadzoneSize));
        }
    }
}



