using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

    int score = 0;
    [SerializeField] int health = 100;
    [SerializeField] int shieldHealth = 0;
    [SerializeField] public int shieldLayer01 = 100;
    [SerializeField] public int shieldLayer02 = 200;
    [SerializeField] public int shieldLayer03 = 300;

    private void Awake()
    {
        SetUpSingleton();
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
}
