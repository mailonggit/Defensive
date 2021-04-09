using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponBluePrint
{
    public GameObject prefab;
    public GameObject upgradePrefab;
    public int cost;
    public int upgradeCost;
    public int SellCost()
    {
        return cost / 2;
    }
}
