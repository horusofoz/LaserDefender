using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config")]

public class WaveConfig : ScriptableObject {

    [Header("Enemy")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 0;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float delaySpawn = 0f;

    [Header("Collectible")]
    [SerializeField] float collectibleSpawnChance = 0.5f;
    [SerializeField] GameObject collectibleItem = null;
    [SerializeField] int enemyToSpawnCollectible = -1;

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

    public float GetSpawnRandomFactor() { return spawnRandomFactor; }

    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public float GetMoveSpeed() { return moveSpeed; }

    public float GetDelayNextSpawn()
    {
        return delaySpawn;
    }

    private void OnEnable()
    {
        if(collectibleSpawnChance > 0)
        {
            float collectibleSpawnRoll = UnityEngine.Random.Range(0f, 1f);
            if(collectibleSpawnRoll <= collectibleSpawnChance)
            {
                SetCollectibleToSpawn();
                SetEnemyToSpawnCollectible();
            }
        }
    }

    private void SetEnemyToSpawnCollectible()
    {
        if(enemyToSpawnCollectible == -1)
        {
            enemyToSpawnCollectible = UnityEngine.Random.Range(0, numberOfEnemies);
        }
    }

    private void SetCollectibleToSpawn()
    {
        if(collectibleItem == null)
        {
            List<GameObject> collectibleItemList = GameSession.Instance.GetCollectiblesList();
            collectibleItem = collectibleItemList[UnityEngine.Random.Range(0, collectibleItemList.Count)];
        }
    }

    public int GetEnemyToSpawnCollectible()
    {
        return enemyToSpawnCollectible;
    }

    public GameObject GetCollectibleToSpawn()
    {
        return collectibleItem;
    }
}
