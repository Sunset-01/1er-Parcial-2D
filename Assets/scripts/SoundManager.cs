using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource m_AudioSource;
    public void SoundEffect()
    {
        m_AudioSource.volume = AUDMAN.Monedaef;
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
    }
}
