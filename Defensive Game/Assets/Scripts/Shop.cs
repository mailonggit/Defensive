using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;
    [SerializeField] private GameObject weapon1Prefab;
    [SerializeField] private GameObject weapon2Prefab;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseWeapon1()
    {
        buildManager.SetWeaponToBuild(weapon1Prefab);
    }
    public void PurchaseWeapon2()
    {
        buildManager.SetWeaponToBuild(weapon2Prefab);
    }

}
