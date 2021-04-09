using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform target;
    [Header("Attributes")]    
    [SerializeField] private float range;
    [SerializeField] private float fireRate;
    private float fireCountdown = 0f;

    [Header("Unity Setup Field")]
    [SerializeField] private string enemyTag;    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        animator = GetComponent<Animator>();
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {            
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            
            if (distanceToEnemy < shortestDistance && enemy.GetComponent<Enemy>().IsActive)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            animator.SetBool("isAttack", true);
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
            animator.SetBool("isAttack", false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }
        
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
        UpdateTarget();
    }
    private void Shoot()
    {        
        GameObject newbullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = newbullet.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range); 
    }
}
