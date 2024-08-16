//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class VolumeSlider : MonoBehaviour
//{
//    public Slider volumeSlider; // Asigna el Slider en el Inspector

//    private void Start()
//    {
//        // Establece el valor inicial del slider
//        volumeSlider.value = AudioManager.instance.GetVolume();
//        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
//    }

//    private void OnVolumeChanged(float value)
//    {
//        AudioManager.instance.SetVolume(value);
//    }
//}

