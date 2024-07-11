using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // El jugador
    public Vector2 offset; // El offset de la c�mara respecto al jugador
    public Vector2 deadZoneSize; // El tama�o de la zona muerta
    public PolygonCollider2D confiner; // El PolygonCollider2D que delimita el escenario
    public float smoothTime = 0.3f; // Tiempo de suavizado para el movimiento de la c�mara

    private Vector3 velocity = Vector3.zero;
    private Vector2 minBound, maxBound;

    void Start()
    {
        // Obt�n los l�mites del confiner
        if (confiner != null)
        {
            Bounds bounds = confiner.bounds;
            minBound = bounds.min;
            maxBound = bounds.max;
        }
        else
        {
            Debug.LogError("Confiner no asignado en el script CameraFollow.");
        }
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player no asignado en el script CameraFollow.");
            return;
        }

        // Calcula la posici�n deseada de la c�mara con el offset
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

        // Calcula los l�mites de la zona muerta
        Vector2 deadZoneMin = (Vector2)transform.position - deadZoneSize / 2;
        Vector2 deadZoneMax = (Vector2)transform.position + deadZoneSize / 2;

        // Verifica si el jugador est� fuera de la zona muerta
        if (player.position.x < deadZoneMin.x || player.position.x > deadZoneMax.x ||
            player.position.y < deadZoneMin.y || player.position.y > deadZoneMax.y)
        {
            // Mueve la c�mara suavemente hacia la posici�n deseada
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        }

        // Aseg�rate de que la c�mara no salga del confiner
        transform.position = ClampCamera(transform.position);
    }

    Vector3 ClampCamera(Vector3 targetPosition)
    {
        // Obt�n el tama�o de la c�mara en unidades del mundo
        Camera camera = Camera.main;
        float vertExtent = camera.orthographicSize;
        float horzExtent = vertExtent * camera.aspect;

        // Limita la posici�n de la c�mara a los l�mites del confiner
        float minX = minBound.x + horzExtent;
        float maxX = maxBound.x - horzExtent;
        float minY = minBound.y + vertExtent;
        float maxY = maxBound.y - vertExtent;

        return new Vector3(
            Mathf.Clamp(targetPosition.x, minX, maxX),
            Mathf.Clamp(targetPosition.y, minY, maxY),
            targetPosition.z
        );
    }

    void OnDrawGizmos()
    {
        // Dibuja la zona muerta en el editor para visualizaci�n
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, deadZoneSize);

        // Dibuja el offset en el editor para visualizaci�n
        if (player != null)
        {
            Gizmos.color = Color.blue;
            Vector3 offsetPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            Gizmos.DrawWireSphere(offsetPosition, 0.1f);
        }
    }
}
