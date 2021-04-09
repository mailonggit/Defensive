using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] private float speed;
    private int waypointIndex = 0;
    private Transform targetPoint;    
    public float Speed
    {
        get => this.speed;
        set { this.speed = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = Waypoints.points[0];        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = targetPoint.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);        
        if (Vector3.Distance(transform.position, targetPoint.position) <= 0.2f)
        {
            MoveToNextPoint();
        }
    }
    void MoveToNextPoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            FinalPath();
            return;
        }
        waypointIndex++;
        targetPoint = Waypoints.points[waypointIndex];
    }
    void FinalPath()
    {        
        PlayerInfo.Lives--;
        Destroy(gameObject);
    }
}
