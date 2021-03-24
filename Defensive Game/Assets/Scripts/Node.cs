using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    private SpriteRenderer spriteRenderer;
    private Color startColor;
    private GameObject weapon;
    private BuildManager buildManager;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        buildManager = BuildManager.instance;
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
        if (buildManager.GetWeaponToBuild() == null)
        {
            return;
        }
        if (weapon != null)
        {
            Debug.Log("Cannot build here");
            return;
        }
        GameObject weaponToBuild = BuildManager.instance.GetWeaponToBuild();
        weapon = (GameObject)Instantiate(weaponToBuild, transform.position, transform.rotation);
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (buildManager.GetWeaponToBuild() == null)
        {
            return;
        }
        if (weapon != null)
        {
            spriteRenderer.color = Color.red;
        }
        else if(weapon == null)
        {
            spriteRenderer.color = Color.green;
        }
        
    }    
    private void OnMouseExit()
    {
        spriteRenderer.color = startColor;
    }
}
