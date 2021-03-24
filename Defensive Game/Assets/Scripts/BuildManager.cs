using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject weaponToBuild;    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Duplicate build manager");
        }
        instance = this;
    }
    

    public GameObject GetWeaponToBuild()
    {
        return weaponToBuild;
    }

    public void SetWeaponToBuild(GameObject weapon)
    {
        weaponToBuild = weapon;
    }
}
