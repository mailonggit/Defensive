using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;
    [SerializeField] private WeaponBluePrint weapon1Prefab;
    [SerializeField] private WeaponBluePrint weapon2Prefab;
    [SerializeField] private WeaponBluePrint weapon3Prefab;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseWeapon1()
    {
        buildManager.SelectWeaponToBuild(weapon1Prefab);
    }
    public void PurchaseWeapon2()
    {
        buildManager.SelectWeaponToBuild(weapon2Prefab);
    }
    public void PurchaseWeapon3()
    {
        buildManager.SelectWeaponToBuild(weapon3Prefab);
    }

}
