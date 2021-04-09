using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{        
    private Animator anim;
    [SerializeField] int health = 100;
    [SerializeField] int reward = 50;
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
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
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
        Destroy(gameObject, 3f);
    }
    // Update is called once per frame
    void Update()
    {

    }

}
