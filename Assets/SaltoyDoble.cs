using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoyDoble : MonoBehaviour
{
    public float fuerzaSalto;
    public int saltosMaximos;
    public LayerMask capaSuelo;


    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private int saltosRestantes;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMaximos;
    }

    private void Update()
    {
        ProcesarSalto();
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }
    void ProcesarSalto()
    {
        if (EstaEnSuelo()) 
        {
            saltosRestantes = saltosMaximos;
        }
        if (InputManager.Moverme() && saltosRestantes > 0)/*(Input.GetKeyDown(KeyCode.W) && saltosRestantes > 0)*/
        {
            saltosRestantes = saltosRestantes - 1;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);

        }
    }
}
