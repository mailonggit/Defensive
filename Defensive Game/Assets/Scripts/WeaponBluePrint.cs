using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WeaponBluePrint
{    
    [SerializeField] private GameObject initialPrefab, up1Prefab, up2Prefab;        
    [SerializeField] private int initialCost, up1Cost, up2Cost;
    
    public GameObject InititalPrefab { get => initialPrefab; }
    public GameObject Upgrade1Prefab { get => up1Prefab; }
    public GameObject Upgrade2Prefab { get => up2Prefab; }
    public int InitialCost { get => initialCost; }
    public int Up1Cost { get => up1Cost; }

    public int Up2Cost { get => up2Cost; }
    public int SellCost()
    {
        return InitialCost / 2;
    }
}
