using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour
{
    [SerializeField] GameObject ui;
    private Node target;
    [SerializeField] private TextMeshProUGUI upgradeCost, sellCost;
    [SerializeField] Vector3 offset;
    [SerializeField] Button upgradeBtn;
    public void SetTarget(Node _target)
    {
        this.target = _target;

        transform.position = target.transform.position - offset;
        if (target.isUpgraded)
        {
            upgradeCost.text = "Finished";
            upgradeBtn.interactable = false;            
        }
        else
        {
            upgradeCost.text = "$" + target.WeaponBluePrint.upgradeCost.ToString();
            sellCost.text = "$" + target.WeaponBluePrint.SellCost().ToString();
            upgradeBtn.interactable = true;
        }

        ui.SetActive(true);        
    }

    public void TurnOffUI()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeWeapon();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellWeapon();
        BuildManager.instance.DeselectNode();
    }
}
