using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float ParallaxMultipier;

    private Transform cameraTransform;
    private Vector3  previousCameraPosition;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
    }

    void Update()
    {
        float deltaX = (cameraTransform.position.x - previousCameraPosition.x) * ParallaxMultipier; 
        transform.Translate(new Vector3(deltaX, 0, 0));
        previousCameraPosition = cameraTransform.position;
    }
}
