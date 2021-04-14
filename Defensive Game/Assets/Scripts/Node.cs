using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{    
    private SpriteRenderer spriteRenderer;

    private Color startColor;

    private BuildManager buildManager;

    //[SerializeField] GameObject shop;
    
    public GameObject Weapon { get; set; }
    public WeaponBluePrint WeaponBluePrint { get; set; }
    public int IsFullyUpgraded { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        buildManager = BuildManager.instance;
        IsFullyUpgraded = 1;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {            
            return;            
        }
        
        if (Weapon != null)
        {
            //select instead of building weapon
            buildManager.SelectNode(this);            
            return;
        }
        else if (Weapon == null)
        {
            buildManager.DeselectNode();
            //shop.SetActive(true);
            //shop.transform.position = this.transform.position;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (this.gameObject.tag == "Grass")
        {
            BuildWeapon(buildManager.GetWeaponToBuild());
        }
        
    }
    private void BuildWeapon(WeaponBluePrint blueprint)
    {
        if (PlayerInfo.Money < blueprint.InitialCost)
        {            
            return;
        }

        WeaponBluePrint = blueprint;

        GameObject newWeapon = (GameObject)Instantiate(blueprint.InititalPrefab, transform.position, Quaternion.identity);
        Weapon = newWeapon;
        PlayerInfo.Money -= blueprint.InitialCost;
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
    public void UpgradeWeapon1st()
    {
        if (PlayerInfo.Money < WeaponBluePrint.Up1Cost)
        {
            Debug.Log("Not enough money!");
            return;

        }

        //get rid of old weapon
        Destroy(Weapon);

        //build new weapon
        GameObject weapon = (GameObject)Instantiate(WeaponBluePrint.Upgrade1Prefab, transform.position, Quaternion.identity);
        Weapon = weapon;
        PlayerInfo.Money -= WeaponBluePrint.Up1Cost;

        IsFullyUpgraded++;

        Debug.Log("Upgraded 1st successfully!!");
    }
    public void UpgradeWeapon2nd()
    {
        if (PlayerInfo.Money < WeaponBluePrint.Up2Cost)
        {
            Debug.Log("Not enough money!");
            return;

        }

        //get rid of old weapon
        Destroy(Weapon);

        //build new weapon
        GameObject weapon = (GameObject)Instantiate(WeaponBluePrint.Upgrade2Prefab, transform.position, Quaternion.identity);
        Weapon = weapon;
        PlayerInfo.Money -= WeaponBluePrint.Up2Cost;

        IsFullyUpgraded++;

        Debug.Log("Upgraded 2nd successfully!!");
    }
    public void SellWeapon()
    {
        PlayerInfo.Money += WeaponBluePrint.SellCost();

        Destroy(Weapon);
        WeaponBluePrint = null;
    }
}
