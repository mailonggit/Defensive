using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WeaponBluePrint
{    
    [SerializeField] private GameObject initPrefab, up1Prefab, up2Prefab;        
    [SerializeField] private int initCost, up1Cost, up2Cost;
    
    public GameObject InititalPrefab { get => initPrefab; }
    public GameObject Up1Prefab { get => up1Prefab; }
    public GameObject Up2Prefab { get => up2Prefab; }
    public int InitCost { get => initCost; }
    public int Up1Cost { get => up1Cost; }
    public int Up2Cost { get => up2Cost; }
}
