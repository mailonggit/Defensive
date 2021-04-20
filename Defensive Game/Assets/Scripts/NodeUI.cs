using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour
{
    [SerializeField] GameObject upAndSellUI;    
    [SerializeField] private TextMeshProUGUI upgradeCost, sellCost;
    [SerializeField] Vector3 offset;
    [SerializeField] Button upgradeBtn;
    private Node target;
    public void SetTarget(Node _target)
    {
        this.target = _target;

        transform.position = target.transform.position - offset;
        if (target.UpgradeNum > 2)
        {
            upgradeCost.text = "Finished";
            upgradeBtn.interactable = false;
            sellCost.text = "$" + (target.WeaponBluePrint.Up2Cost / 2).ToString();            
        }
        else
        {
            if (target.UpgradeNum == 1)
            {
                upgradeCost.text = "$" + target.WeaponBluePrint.Up1Cost.ToString();
                sellCost.text = "$" + (target.WeaponBluePrint.InitCost / 2).ToString();
            }
            else if (target.UpgradeNum == 2)
            {
                upgradeCost.text = "$" + target.WeaponBluePrint.Up2Cost.ToString();
                sellCost.text = "$" + (target.WeaponBluePrint.Up1Cost / 2).ToString();
            }
            upgradeBtn.interactable = true;
        }       

        upAndSellUI.SetActive(true);        
    }

    public void TurnOffUI()
    {
        upAndSellUI.SetActive(false);
    }
    public void Upgrade()
    {
        if (target.UpgradeNum == 1)
        {
            target.Upgrade1();
        }
        else if (target.UpgradeNum == 2)
        {
            target.Upgrade2();
        }
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        if (target.UpgradeNum == 1)
        {
            target.Sell1();
        }
        else if (target.UpgradeNum == 2)
        {
            target.Sell2();
        }
        else if (target.UpgradeNum == 3)
        {
            target.Sell3();
        }
        BuildManager.instance.DeselectNode();
        target.IsExist = false;
    }
}
