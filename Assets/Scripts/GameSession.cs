using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

    public static GameSession Instance { get; private set; }

    [Header("Shield")]
    [SerializeField] int health = 100;
    int healthMax = 100;
    [SerializeField] int shieldHealth = 0;
    [SerializeField] public int shieldLayer01 = 100;
    [SerializeField] public int shieldLayer02 = 200;
    [SerializeField] public int shieldLayer03 = 300;

    [Header("Projectile")]
    [SerializeField] GameObject weapon;
    [SerializeField] int weaponLevel = 0;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.5f;
    [SerializeField] List<GameObject> weaponsList;
    [SerializeField] ParticleSystem weaponBoostVFX;

    [Header("Other")]
    [SerializeField] int playerMovementSpeed = 4;
    [SerializeField] List<GameObject> collectiblesList;
    [SerializeField] GameObject player;
    int score = 0;

    private void Awake()
    {
        SetUpSingleton();
        SetWeapon(0);
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

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        //health = 100;
        //shieldHealth = 0;
        //weaponLevel = 0;
        //playerMovementSpeed = 4;
        //score = 0;
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }

    public void SubtractHealth(int healthValue)
    {
        if(shieldHealth > 0)
        {
            SubtractShieldHealth(healthValue);
        }
        else
        {
            health = Mathf.Clamp((health -= healthValue), 0, healthMax);
        }
    }

    public void AddHealth(int healthValue)
    {
        health = Mathf.Clamp((health += healthValue), 0, healthMax);
    }

    public int GetShieldHealth()
    {
        return shieldHealth;
    }

    public void SubtractShieldHealth(int healthValue)
    {
        shieldHealth -= healthValue;
    }

    public void AddShieldHealth(int healthValue)
    {
        shieldHealth = Mathf.Clamp((shieldHealth += healthValue), 0, shieldLayer03);
        
    }

    public List<GameObject> GetCollectiblesList()
    {
        return collectiblesList;
    }

    public GameObject GetWeapon()
    {
        return weapon;
    }

    public void SetWeapon(int weaponBoostValue)
    {
        if(player != null)
        {
            weaponLevel = Mathf.Clamp((weaponLevel + weaponBoostValue), 0, weaponsList.Count - 1);
            weapon = weaponsList[weaponLevel];
            player.GetComponent<Player>().SetWeapon();
            //PlayWeaponBoostVFX();
        }
    }

    private void PlayWeaponBoostVFX()
    {
        if(weaponLevel > 0)
        {
            ParticleSystem boostVFX = Instantiate(weaponBoostVFX, player.transform.position, Quaternion.identity);
            Destroy(boostVFX.gameObject, 1f);
        }
    }

    public int GetPlayerSpeed()
    {
        return playerMovementSpeed;
    }

    public void SetPlayerSpeed(int speedValue)
    {
        playerMovementSpeed = speedValue;
    }

    public void AddPlayerSpeed(int speedValue)
    {
        playerMovementSpeed += speedValue;
        player.GetComponent<Player>().SetSpeed();
    }
}
