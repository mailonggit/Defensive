using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed, explosionRadius;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private int damage;    
    [SerializeField] private bool isSlow;
    [SerializeField] private float slowTime;
    public void Seek(Transform target)
    {
        this.target = target;
    }
    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }
    private void HitTarget()
    {
        GameObject bulletEffect = (GameObject)Instantiate(impactEffect, target.position, target.rotation);
        bulletEffect.transform.position = new Vector3(bulletEffect.transform.position.x, bulletEffect.transform.position.y, -5);
        Destroy(bulletEffect, 0.5f);

        if (isSlow)
        {
            Slow();            
        }
        else if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
        
    }
    void Slow()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), explosionRadius);        
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {                
                collider.GetComponent<Enemy>().SlowTime = slowTime;
                Damage(collider.transform);                
            }
        }
    }
    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }
    private void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        // if e is not null
        if (e != null)
        {
            e.TakeDamage(damage);
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
