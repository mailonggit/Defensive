using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;    
    [SerializeField] private float countdown, timeBetweenWave;    
    private int waveIndex = 0;
    public static int EnemyAlives = 0;
    [SerializeField] Wave[] waves;
    void Update()
    {
        if (EnemyAlives > 0)
        {
            return;
        }
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());            
            countdown = timeBetweenWave;
            return;
        }
        countdown -= Time.deltaTime;
        
    }
    IEnumerator SpawnWave()
    {              
        PlayerInfo.Rounds++;
        Wave wave = waves[waveIndex];
        for (int i = 0; i < wave.NumberOfEnemy; i++)
        {
            SpawnEnemy(wave.Enemy);
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;

        if (waveIndex == waves.Length)
        {
            Debug.Log("Level Completed!!");
            this.enabled = false;
        }
    }
    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemyAlives++;
    }
}
