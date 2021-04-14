using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Shop : MonoBehaviour
{
    private BuildManager buildManager;
    [SerializeField] private WeaponBluePrint wp1Prefab, wp2Prefab, wp3Prefab, wp4Prefab;
    [SerializeField] private TextMeshProUGUI wp1Cost, wp2Cost, wp3Cost, wp4Cost;
    private void Start()
    {
        buildManager = BuildManager.instance;
        wp1Cost.text = wp1Prefab.InitialCost.ToString();
        wp2Cost.text = wp2Prefab.InitialCost.ToString();
        wp3Cost.text = wp3Prefab.InitialCost.ToString();
        wp4Cost.text = wp4Prefab.InitialCost.ToString();
    }
    public void PurchaseWeapon1()
    {
        buildManager.SelectWeaponToBuild(wp1Prefab);
    }
    public void PurchaseWeapon2()
    {
        buildManager.SelectWeaponToBuild(wp2Prefab);
    }
    public void PurchaseWeapon3()
    {
        buildManager.SelectWeaponToBuild(wp3Prefab);
    }
    public void PurchaseWeapon4()
    {
        buildManager.SelectWeaponToBuild(wp4Prefab);
    }

}
