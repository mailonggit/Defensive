using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ShopUI : MonoBehaviour
{
    [SerializeField] GameObject shopUI;
    private Node target;       
    private BuildManager buildManager;
    [SerializeField] Vector3 offset;
    [SerializeField] private WeaponBluePrint wp1Prefab, wp2Prefab, wp3Prefab, wp4Prefab;
    [SerializeField] private TextMeshProUGUI wp1Cost, wp2Cost, wp3Cost, wp4Cost;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SetTarget(Node _target)
    {
        this.target = _target;

        transform.position = target.transform.position - offset;

        wp1Cost.text = "$" + wp1Prefab.InitCost.ToString();
        wp2Cost.text = "$" + wp2Prefab.InitCost.ToString();
        wp3Cost.text = "$" + wp3Prefab.InitCost.ToString();
        wp4Cost.text = "$" + wp4Prefab.InitCost.ToString();

        shopUI.SetActive(true);
        
    }    
    public void TurnOffUI()
    {
        shopUI.SetActive(false);
    }
    public void PurchaseWeapon1()
    {

        buildManager.SelectWeaponToBuild(wp1Prefab);

        target.BuildWeapon(wp1Prefab);

        BuildManager.instance.DeselectNode();
    }
    public void PurchaseWeapon2()
    {
        buildManager.SelectWeaponToBuild(wp2Prefab);

        target.BuildWeapon(wp2Prefab);

        BuildManager.instance.DeselectNode();
    }
    public void PurchaseWeapon3()
    {
        buildManager.SelectWeaponToBuild(wp3Prefab);

        target.BuildWeapon(wp3Prefab);

        BuildManager.instance.DeselectNode();
    }
    public void PurchaseWeapon4()
    {        
        buildManager.SelectWeaponToBuild(wp4Prefab);

        target.BuildWeapon(wp4Prefab);

        BuildManager.instance.DeselectNode();
    }
} 
