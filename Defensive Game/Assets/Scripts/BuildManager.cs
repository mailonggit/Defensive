using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private WeaponBluePrint weaponToBuild;
    private Node selectedNode;
    [SerializeField] NodeUI nodeUI;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Duplicate build manager");
        }
        instance = this;
    }
    
    public bool CanBuild
    {
        get => weaponToBuild != null;
    }
    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        weaponToBuild = null;
        nodeUI.SetTarget(node);
       
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.TurnOffUI();
    }
    public void SelectWeaponToBuild(WeaponBluePrint weapon)
    {
        weaponToBuild = weapon;
        DeselectNode(); 
    }
    public WeaponBluePrint GetWeaponToBuild()
    {
        return weaponToBuild;
    }
}
