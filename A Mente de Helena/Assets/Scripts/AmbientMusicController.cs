using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusicController : MonoBehaviour
{
    private AudioSource audioSrc;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject); // Mantém entre cenas
    }

    public void PlayMusic()
    {
        if (!audioSrc.isPlaying)
            audioSrc.Play();
    }

    public void StopMusic()
    {
        if (audioSrc.isPlaying)
            audioSrc.Stop();
    }
}
