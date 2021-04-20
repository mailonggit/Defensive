using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{    
    private SpriteRenderer spriteRenderer;

    private Color startColor;

    private BuildManager buildManager;
    
    public GameObject Weapon { get; set; }    
    public WeaponBluePrint WeaponBluePrint { get; set; }
    public int UpgradeNum { get; set; }
    
    public bool IsExist { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        buildManager = BuildManager.instance;
        UpgradeNum = 1;
        IsExist = false;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {            
            return;            
        }
        if (this.gameObject.tag == buildManager.NodeTag)
        {
            if (Weapon != null)
            {
                //select instead of building weapon
                buildManager.SelectNode(this);
                return;
            }
            else if (Weapon == null)
            {
                buildManager.SelectNode(this);
                //buildManager.DeselectNode();         
            }
            if (!buildManager.CanBuild)
            {
                return;
            }
            BuildWeapon(buildManager.GetWeaponToBuild());
        }
                        
    }
    public void BuildWeapon(WeaponBluePrint blueprint)
    {
        if (PlayerInfo.Money < blueprint.InitCost)
        {            
            return;
        }

        WeaponBluePrint = blueprint;

        GameObject newWeapon = (GameObject)Instantiate(blueprint.InititalPrefab, transform.position, Quaternion.identity);

        Weapon = newWeapon;

        IsExist = true;

        PlayerInfo.Money -= blueprint.InitCost;        
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {            
            return;
        }               
    }    
    private void OnMouseExit()
    {
        spriteRenderer.color = startColor;
    }
    public void Upgrade1()
    {
        if (PlayerInfo.Money < WeaponBluePrint.Up1Cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        //get rid of old weapon
        Destroy(Weapon);

        //build new weapon
        GameObject weapon = (GameObject)Instantiate(WeaponBluePrint.Up1Prefab, transform.position, Quaternion.identity);
        Weapon = weapon;
        PlayerInfo.Money -= WeaponBluePrint.Up1Cost;

        UpgradeNum++;

        Debug.Log("Upgrade " + UpgradeNum + " time successfully");
        
    }
    public void Upgrade2()
    {
        if (PlayerInfo.Money < WeaponBluePrint.Up2Cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        //get rid of old weapon
        Destroy(Weapon);

        //build new weapon
        GameObject weapon = (GameObject)Instantiate(WeaponBluePrint.Up2Prefab, transform.position, Quaternion.identity);
        Weapon = weapon;
        PlayerInfo.Money -= WeaponBluePrint.Up2Cost;

        UpgradeNum++;

        Debug.Log("Upgrade " + UpgradeNum + " time successfully");

    }
    public void Sell1()
    {
        PlayerInfo.Money += WeaponBluePrint.InitCost / 2;

        Destroy(Weapon);

        WeaponBluePrint = null;
    }
    public void Sell2()
    {
        PlayerInfo.Money += WeaponBluePrint.Up1Cost / 2;

        Destroy(Weapon);

        WeaponBluePrint = null;
    }
    public void Sell3()
    {
        PlayerInfo.Money += WeaponBluePrint.Up2Cost / 2;

        Destroy(Weapon);

        WeaponBluePrint = null;

        //reset
        UpgradeNum = 1;
    }
}
