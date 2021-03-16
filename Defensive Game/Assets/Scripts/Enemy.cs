using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    [SerializeField] private float speed;
    private Animator anim;
    private int waypointIndex = 0;  
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = this.waypoints[waypointIndex].transform.position;
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position,
            this.waypoints[waypointIndex].transform.position, this.speed * Time.deltaTime);
        if (this.transform.position == this.waypoints[waypointIndex].transform.position)
        {
            this.waypointIndex += 1;
        }
        if (this.waypointIndex == this.waypoints.Length)
        {
            //destroy this object            
            this.anim.SetBool("isDead", true);
            //this.waypointIndex = 0;            
        }
    }
}
