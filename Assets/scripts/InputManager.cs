using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private static PlayerInput inputman;
    
    void Start()
    {
        inputman = GetComponent<PlayerInput>();
    }

    public static Vector2 moveplayer()
    {
        return inputman.actions.FindAction("Move").ReadValue<Vector2>();
    }
    
    public static bool Shuut()
    { 
        return inputman.actions.FindAction("Shoot").IsPressed();

    }

    public static bool Moverme()
    {
        return inputman.actions.FindAction("Movers").WasPressedThisFrame();

    }

    public static bool Dash()
    {
        return inputman.actions.FindAction("Dash").WasPressedThisFrame();

    }

    public static bool Correr()
    {
        return inputman.actions.FindAction("Correr").IsPressed();

    }
}
