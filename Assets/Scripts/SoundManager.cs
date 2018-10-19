using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance { get; private set; }

    [SerializeField] AudioClip playerShotSFX, playerDeadSFX, enemyDeadSFX, enemyShotSFX, buttonClickSFX;
    [SerializeField] [Range(0, 1)] float masterVolume = 1f;
    [SerializeField] [Range(0, 1)] float sFXVolume = 1f;
    [SerializeField] [Range(0, 1)] float playerShotVolume = 1f;
    [SerializeField] [Range(0, 1)] float playerDeadVolume =  1f;
    [SerializeField] [Range(0, 1)] float enemyShotVolume = 1f;
    [SerializeField] [Range(0, 1)] float enemyDeadVolume = 1f;
    [SerializeField] [Range(0, 1)] float buttonClickVolume = 1f;

    private void Awake()
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


    public void TriggerPlayerShotSFX()
    {
        AudioSource.PlayClipAtPoint(playerShotSFX, 
            Camera.main.transform.position, 
            playerShotVolume * (sFXVolume * masterVolume));
    }

    public void TriggerPlayerDeadSFX()
    {
        AudioSource.PlayClipAtPoint(playerDeadSFX,
            Camera.main.transform.position,
            playerShotVolume * (sFXVolume * masterVolume));
    }

    public void TriggerEnemyShotSFX()
    {
        AudioSource.PlayClipAtPoint(enemyShotSFX,
            Camera.main.transform.position, 
            enemyShotVolume * (sFXVolume * masterVolume));
    }

    public void TriggerEnemyDeadSFX()
    {
        AudioSource.PlayClipAtPoint(enemyDeadSFX, 
            Camera.main.transform.position, 
            enemyShotVolume * (sFXVolume * masterVolume));
    }

    public void TriggerButtonClickSFX()
    {
        AudioSource.PlayClipAtPoint(enemyDeadSFX,
            Camera.main.transform.position,
            enemyShotVolume * (sFXVolume * masterVolume));
    }
}
