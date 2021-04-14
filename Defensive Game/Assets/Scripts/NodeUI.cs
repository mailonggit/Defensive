using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour
{
    [SerializeField] GameObject upAndSellUI;
    private Node target;
    [SerializeField] private TextMeshProUGUI upgradeCost, sellCost;
    [SerializeField] Vector3 offset;
    [SerializeField] Button upgradeBtn;
    public void SetTarget(Node _target)
    {
        this.target = _target;

        transform.position = target.transform.position - offset;
        if (target.IsFullyUpgraded > 2)
        {
            upgradeCost.text = "Finished";
            upgradeBtn.interactable = false;            
        }
        else if(target.IsFullyUpgraded == 1)
        {
            upgradeCost.text = "$" + target.WeaponBluePrint.Up1Cost.ToString();
            sellCost.text = "$" + target.WeaponBluePrint.SellCost().ToString();
            upgradeBtn.interactable = true;
        }
        else if (target.IsFullyUpgraded == 2)
        {
            upgradeCost.text = "$" + target.WeaponBluePrint.Up2Cost.ToString();
            sellCost.text = "$" + target.WeaponBluePrint.SellCost().ToString();
            upgradeBtn.interactable = true;
        }

        upAndSellUI.SetActive(true);        
    }

    public void TurnOffUI()
    {
        upAndSellUI.SetActive(false);
    }
    public void Upgrade1st()
    {
        target.UpgradeWeapon1st();
        BuildManager.instance.DeselectNode();
    }
    public void Upgrade2nd()
    {
        target.UpgradeWeapon2nd();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellWeapon();
        BuildManager.instance.DeselectNode();
    }
}
