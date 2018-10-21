﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

	// Use this for initialization
	IEnumerator Start () 
	{
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
	}

    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];

            Debug.Log("Spawning Wave: " + waveConfigs[waveIndex].name);

            // Wait until waveConfig.delayNextSpawn before spawning next wave
            yield return new WaitForSeconds(currentWave.GetDelayNextSpawn());

            StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
            waveConfig.GetEnemyPrefab(),
            waveConfig.GetWaypoints()[0].transform.position,
            Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            

            if(enemyCount == waveConfig.GetEnemyToSpawnCollectible())
            {
                newEnemy.GetComponent<Enemy>().SetCollectibleItem(waveConfig.GetCollectibleToSpawn());
                Debug.Log("Set collectiable to spawn " + waveConfig.GetCollectibleToSpawn() + " on Enemy " + enemyCount);
            }

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }

        
    }
}
