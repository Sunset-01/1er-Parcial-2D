using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AUDMAN : MonoBehaviour
{
    public static float Monedaef;
    public static float Music;

    [SerializeField] private Scrollbar scrollbarmonedas;



    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private AudioSource audiosource;
    

    private void Start()
    {
        Music = scrollbar.value;
        Monedaef = scrollbarmonedas.value;
    }
    private void Update()
    {
        Monedaef =scrollbarmonedas.value;

        Music = scrollbar.value;
        audiosource.volume = Music;
    }
}
