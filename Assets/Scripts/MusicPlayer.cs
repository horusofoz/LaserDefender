using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public static MusicPlayer Instance { get; private set; }

    [SerializeField] [Range(0, 1)] float musicVolume = 0.5f;
    [SerializeField] AudioSource audioSource;

    // Use this for initialization
    void Awake () 
	{
        SetUpSingleton();
	}

    private void SetUpSingleton()
    {
        // First we check if there are any other instances conflicting
        if (Instance != null)
        {
            // If that is the case, we destroy other instances
            Destroy(gameObject);
        }
        else
        {
            // Here we save our singleton instance
            Instance = this;

            // Furthermore we make sure that we don't destroy between scenes (this is optional)
            DontDestroyOnLoad(gameObject);
        }
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public void SetMusicVolume(float newVolume)
    {
        musicVolume = newVolume;
        audioSource.volume = musicVolume;
    }


}
