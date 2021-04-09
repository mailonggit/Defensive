using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float countdown;
    [SerializeField] private float timeBetweenWave;
    private int waveIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());            
            countdown = timeBetweenWave;
        }
        countdown -= Time.deltaTime;
        
    }
    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerInfo.Rounds++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
