using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float xMax, xMin, yMax, yMin, size;
    [SerializeField] GameObject maxNode;    
    // Start is called before the first frame update
    private void Start()
    {
        size = maxNode.GetComponent<SpriteRenderer>().bounds.size.x;
        SetLimit();        
    }
    void Update()
    {
        if (GameManager.isGameOver)
        {
            this.enabled = false;
            return;
        }
        MoveCamera();
    }
    private void MoveCamera()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * this.speed);            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.down * Time.deltaTime * this.speed);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * this.speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.up * Time.deltaTime * this.speed);            
        }        
        float x = Mathf.Clamp(transform.position.x, xMin, xMax );
        float y = Mathf.Clamp(transform.position.y, yMax, yMin );        
        transform.position = new Vector3(x, y, -10);
    }
    private void SetLimit()
    {

        //bottom left: 0,0
        //top left: 0,1
        //bottom right: 1,0
        //top right: 1,1

        Vector3 worldPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));        
        //calculate distance from camera to last node
        xMax = maxNode.transform.position.x - worldPoint.x + size / 2;
        xMin = -size;
        yMin = maxNode.transform.position.y - worldPoint.y + size / 2;
        yMax = 0;
    }
    
}
