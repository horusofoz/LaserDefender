using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config")]

public class WaveConfig : ScriptableObject {

    [Header("Enemy")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0f;
    //[SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 0;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float delaySpawn = 0f;

    [Header("Boost")]
    [SerializeField] float boostSpawnChance = 0.5f;
    [SerializeField] GameObject boostItem = null;
    [SerializeField] int enemyToSpawnBoost = -1;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    //public float GetSpawnRandomFactor() { return spawnRandomFactor; }

    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public float GetMoveSpeed() { return moveSpeed; }

    public float GetDelayNextSpawn()
    {
        return delaySpawn;
    }

    private void OnEnable()
    {
        if(boostSpawnChance > 0)
        {
            float boostSpawnRoll = UnityEngine.Random.Range(0f, 1f);
            if(boostSpawnRoll <= boostSpawnChance)
            {
                SetBoostToSpawn();
                SetEnemyToSpawnBoost();
            }
        }
    }

    private void SetEnemyToSpawnBoost()
    {
        if(enemyToSpawnBoost == -1)
        {
            enemyToSpawnBoost = UnityEngine.Random.Range(0, numberOfEnemies);
        }
    }

    private void SetBoostToSpawn()
    {
        if(boostItem == null)
        {
            Debug.Log(name + "called SetBoostToSpawn");
            List<GameObject> boostItemList = GameSession.Instance.GetboostList();
            boostItem = boostItemList[UnityEngine.Random.Range(0, boostItemList.Count)];
        }
    }

    public int GetEnemyToSpawnBoost()
    {
        return enemyToSpawnBoost;
    }

    public GameObject GetBoostToSpawn()
    {
        return boostItem;
    }
}
