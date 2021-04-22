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
    private float initialSpeed;
    private EnemyPathing path;    
    public float SlowTime { get; set; }
    public bool IsActive
    {
        get;set;
    }
    private void Update()
    {
        //if enemy is alive => slow if needed
        if (IsActive)
        {
            if (SlowTime > 0)
            {
                //keep slowing enemy when slow time > 0 and alive
                path.Speed = initialSpeed / 2;
                GetComponent<SpriteRenderer>().color = Color.blue;
                SlowTime -= Time.deltaTime;                
            }
            else
            {
                path.Speed = initialSpeed;
                SlowTime = 0;
                GetComponent<SpriteRenderer>().color = Color.white;                
            }            
        }
        

    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        path = GetComponent<EnemyPathing>();
        IsActive = true;
        startHealth = health;
        initialSpeed = path.Speed;
        SlowTime = 0;
        
    }
    public void TakeDamage(float amount)
    {
        //this if statement has to be run once        
        health -= amount;
        healthbar.fillAmount = health / startHealth;
        if (health <= 0 && IsActive)
        {
            Dead();
            return;
        }
    }
    private void Dead()
    {                
        IsActive = false;

        PlayerInfo.Money += reward;

        anim.SetBool("isDead", true);

        path.Speed = 0;        

        Destroy(gameObject, 3f);

        
        WaveSpawner.EnemyAlives -= 1f;
        Debug.Log("After: " + WaveSpawner.EnemyAlives);
        return;
        

    }    

}
