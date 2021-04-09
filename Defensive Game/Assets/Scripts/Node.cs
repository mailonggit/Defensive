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
    public bool isUpgraded { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        buildManager = BuildManager.instance;
        isUpgraded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (PlayerInfo.Money < blueprint.cost)
        {
            Debug.Log("Not enough money!");
            return;

        }

        WeaponBluePrint = blueprint;

        GameObject newWeapon = (GameObject)Instantiate(blueprint.prefab, transform.position, Quaternion.identity);
        Weapon = newWeapon;
        PlayerInfo.Money -= blueprint.cost;
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
    public void UpgradeWeapon()
    {
        if (PlayerInfo.Money < WeaponBluePrint.upgradeCost)
        {
            Debug.Log("Not enough money!");
            return;

        }

        //get rid of old weapon
        Destroy(Weapon);

        //build new weapon
        GameObject weapon = (GameObject)Instantiate(WeaponBluePrint.upgradePrefab, transform.position, Quaternion.identity);
        Weapon = weapon;
        PlayerInfo.Money -= WeaponBluePrint.upgradeCost;

        isUpgraded = true;

        Debug.Log("Upgraded");
    }
    public void SellWeapon()
    {
        PlayerInfo.Money += WeaponBluePrint.SellCost();

        Destroy(Weapon);
        WeaponBluePrint = null;
    }
}
