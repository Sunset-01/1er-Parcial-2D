using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class ahoraSiDest : MonoBehaviour
{
    public float velocidad = 1;

    void Update()
    {
        transform.position = new Vector2(
                               transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * velocidad,
                               transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * velocidad);
    }
}
