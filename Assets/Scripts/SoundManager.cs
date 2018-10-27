using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance { get; private set; }

    [SerializeField] AudioClip playerShotSFX, playerDeadSFX, enemyDeadSFX, enemyShotSFX, buttonClickSFX;

    [SerializeField] AudioSource audioSource;

    [SerializeField] [Range(0, 1)] float sFXVolume = 0.5f;
    [SerializeField] [Range(0, 1)] float playerShotVolume = 1f;
    [SerializeField] [Range(0, 1)] float playerDeadVolume =  1f;
    [SerializeField] [Range(0, 1)] float enemyShotVolume = 1f;
    [SerializeField] [Range(0, 1)] float enemyDeadVolume = 1f;
    [SerializeField] [Range(0, 1)] float buttonClickVolume = 1f;

    private void Awake()
    {
        SetUpSingleton();
        SetSFXVolume(sFXVolume);
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


    public void TriggerPlayerShotSFX()
    {
        audioSource.PlayOneShot(playerShotSFX, (sFXVolume * playerShotVolume));
    }

    public void TriggerPlayerDeadSFX()
    {
        audioSource.PlayOneShot(playerDeadSFX, (sFXVolume * playerDeadVolume));
    }

    public void TriggerEnemyShotSFX()
    {
        audioSource.PlayOneShot(enemyShotSFX, (sFXVolume * enemyShotVolume));
    }

    public void TriggerEnemyDeadSFX()
    {
        audioSource.PlayOneShot(enemyDeadSFX, (sFXVolume * enemyShotVolume));
    }

    public void TriggerButtonClickSFX()
    {
        audioSource.PlayOneShot(enemyDeadSFX, (sFXVolume * enemyShotVolume));
    }

    public float GetSFXVolume()
    {
        return sFXVolume;
    }

    public void SetSFXVolume(float newVolume)
    {
        sFXVolume = newVolume;
        audioSource.volume = sFXVolume;
    }
}
