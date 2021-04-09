using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float xMax, yMin;
    [SerializeField] Transform maxNode;
    private float xOffset, yOffset;
    // Start is called before the first frame update
    private void Start()
    {
        SetLimit();
        xOffset = Mathf.RoundToInt(maxNode.GetComponent<SpriteRenderer>().bounds.size.x);
        yOffset = xOffset;
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
        float x = Mathf.Clamp(transform.position.x, -xOffset, xMax + xOffset);
        float y = Mathf.Clamp(transform.position.y, 0, yOffset);        
        transform.position = new Vector3(x, y, -10);
    }
    private void SetLimit()
    {
        Vector3 worldPoint = Camera.main.ViewportToWorldPoint(new Vector3(1, 0));        
        xMax = maxNode.position.x - worldPoint.x;
        yMin = maxNode.position.y - worldPoint.y;
    }
    
}
