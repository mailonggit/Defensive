using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave 
{
    [SerializeField] GameObject enemy;
    [SerializeField] int numberOfEnemy;
    [SerializeField] float spawnRate;

    public GameObject Enemy { get => enemy; }
    public int NumberOfEnemy { get => numberOfEnemy;}
    public float SpawnRate { get => spawnRate; }

}
