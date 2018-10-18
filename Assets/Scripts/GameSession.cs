using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

    [Header("Shield")]
    [SerializeField] int health = 100;
    [SerializeField] int shieldHealth = 0;
    [SerializeField] public int shieldLayer01 = 100;
    [SerializeField] public int shieldLayer02 = 200;
    [SerializeField] public int shieldLayer03 = 300;

    [Header("Projectile")]
    GameObject weapon;
    int _weaponLevel = 0;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.5f;
    [SerializeField] List<GameObject> weaponsList;
    [SerializeField] ParticleSystem weaponBoostVFX;

    [Header("Other")]
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
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
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
            health -= healthValue;
        }
    }

    public void AddHealth(int healthValue)
    {
        health += healthValue;
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
        shieldHealth += healthValue;
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
        _weaponLevel = Mathf.Clamp((_weaponLevel + weaponBoostValue), 0, weaponsList.Count - 1);   
        weapon = weaponsList[_weaponLevel];
        player.GetComponent<Player>().UpdateWeaponConfig();
        PlayWeaponBoostVFX();
    }

    private void PlayWeaponBoostVFX()
    {
        if(_weaponLevel > 0)
        {
            ParticleSystem boostVFX = Instantiate(weaponBoostVFX, player.transform.position, Quaternion.identity);
            Destroy(boostVFX.gameObject, 1f);
        }
    }
}
