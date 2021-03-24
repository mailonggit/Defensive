using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed;
    [SerializeField] GameObject impactEffect;
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
        Destroy(gameObject);
    }
}
