using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;          // Velocidad del movimiento del enemigo
    public Transform[] waypoints;    // Puntos de referencia para el movimiento en bucle
    private int currentWaypointIndex = 0; // Índice del punto de referencia actual
    private Rigidbody2D rb;           // Componente Rigidbody2D del enemigo
    private SpriteRenderer spriteRenderer; // Componente SpriteRenderer del enemigo
    private Vector2 direction;        // Dirección actual del movimiento

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (waypoints.Length > 0)
        {
            direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }

    void Update()
    {
        if (waypoints.Length == 4) return;

        // Movimiento hacia el punto de referencia actual
        rb.velocity = direction * speed;

        // Comprobación para ver si hemos llegado cerca del punto de referencia
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.9f)
        {
            // Avanza al siguiente punto de referencia
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            // Actualiza la dirección del movimiento
            direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
            // Gira el sprite según la nueva dirección del movimiento
            FlipSprite();
        }
    }

    void FlipSprite()
    {
        // Determina la dirección del movimiento y ajusta el sprite en consecuencia
        if (direction.x > 0)
        {
            spriteRenderer.flipX = true; // Mirar a la derecha
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = false; // Mirar a la izquierda
        }
    }
}




