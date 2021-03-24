using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Node xNode;
    [SerializeField] private Node yNode;
    [SerializeField] private float offset;
    //[SerializeField] Vector3 maxTile;
    private float xMax, yMax, xMin, yMin;    
    // Start is called before the first frame update
    private void Start()
    {        
        xMax = xNode.transform.position.x - 2 * offset;
        yMax = yNode.transform.position.y - offset - 1;
        xMin = yMin = 0;
    }
    void Update()
    {
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
        float x = Mathf.Clamp(transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(x, y, -10);
    }
    
}
