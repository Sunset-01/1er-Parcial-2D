using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;

    [SerializeField] private float velocidadDeMovimiento;
    [SerializeField] private float suavizadoDeMovimiento;
    [SerializeField] private float velocidadDeCorrer;
    [SerializeField] private float tiempoDeDash;
    [SerializeField] private float fuerzaDeDash;
    [SerializeField] private float tiempoDeRecargaDash; 

    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    private bool estaHaciendoDash = false;
    private float tiempoDesdeUltimoDash = 0f;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        if (InputManager.Correr())
        {
            movimientoHorizontal *= velocidadDeCorrer;
        }
            
        if (InputManager.Dash() && !estaHaciendoDash && tiempoDesdeUltimoDash >= tiempoDeRecargaDash)
        {
            StartCoroutine(Dash());
        }

        if (tiempoDesdeUltimoDash < tiempoDeRecargaDash)
        {
            tiempoDesdeUltimoDash += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (!estaHaciendoDash)
        {
            Mover(movimientoHorizontal * Time.fixedDeltaTime);
        }
    }

    private void Mover(float mover)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        
    }

    private IEnumerator Dash()
    {
        estaHaciendoDash = true;
        tiempoDesdeUltimoDash = 0f; 

        float direccionDash = movimientoHorizontal > 0 ? 1 : -1;
        rb2D.velocity = new Vector2(direccionDash * fuerzaDeDash, rb2D.velocity.x);
        
        yield return new WaitForSeconds(tiempoDeDash);

        rb2D.velocity = new Vector2(0, rb2D.velocity.y); 
        estaHaciendoDash = false;
    }
}


