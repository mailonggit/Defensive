using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    
    private Animator anim;
    private float startHealth;
    [SerializeField] float health;
    [SerializeField] private Image healthbar;
    [SerializeField] int reward;
    private EnemyPathing path;
    public bool IsActive
    {
        get;set;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        path = GetComponent<EnemyPathing>();
        IsActive = true;
        startHealth = health;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthbar.fillAmount = health / startHealth;        
        if (health <= 0)
        {            
            Dead();
        }        
    }
    private void Dead()
    {
        IsActive = false;
        PlayerInfo.Money += reward;
        anim.SetBool("isDead", true);
        path.Speed = 0;
        WaveSpawner.EnemyAlives--;
        Destroy(gameObject, 3f);

    }    

}
