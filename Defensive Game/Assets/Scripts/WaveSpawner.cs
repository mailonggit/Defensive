using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float countdown, timeBetweenWave;
    [SerializeField] Wave[] waves;
    [SerializeField] TextMeshProUGUI timerTMP;
    private int waveIndex = 0;
    public static int EnemyAlives = 0;
    private void Start()
    {
        GetComponent<PlayerInfoUI>().MaxRound = waves.Length;
    }
    void Update()
    {
        if (waveIndex == waves.Length)
        {
            GetComponent<GameManager>().FinishedLevel();
            this.enabled = false;
        }
        //if there is enemy => do nothing
        if (EnemyAlives > 0)
        {
            return;
        }
        //if there is no enemy => count down        
        if (countdown > 0)
        {
            //enabled notification for player to prepare
            timerTMP.enabled = true;
            timerTMP.text = "You Have " + Mathf.RoundToInt(countdown).ToString() + "S To Prepare For Wave " + (waveIndex + 1).ToString();            
        }
        else
        {
            //turn off notification and spawn enemy
            timerTMP.enabled = false;            
            StartCoroutine(SpawnWave());           
            //reset countdown time
            countdown = timeBetweenWave; //reset time            
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        //increase round each time spawn a wave
        PlayerInfo.Rounds++;
        //get single wave
        Wave wave = waves[waveIndex];

        //get amount of enemy alives in this round
        EnemyAlives = wave.NumberOfEnemy;

        //spawn each enemies in a wave
        for (int i = 0; i < wave.NumberOfEnemy; i++)
        {
            SpawnEnemy(wave.Enemy);
            yield return new WaitForSeconds(1f / wave.SpawnRate);
        }
        //increase to the next wave
        waveIndex++;        
    }
    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
