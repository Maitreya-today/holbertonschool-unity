using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseS = 4f;
    // public GameObject player;
    public GameObject player;
    private Vector3 offset;
    private Quaternion camRotX;
    private Quaternion camRotY;
    public bool isInverted;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInverted == true)
        {
            if(Input.GetMouseButton(1))
            {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseS, Vector3.up) * Quaternion.AngleAxis((Input.GetAxis("Mouse Y") * -1) * mouseS, Vector3.left) * offset;
            transform.position = player.transform.position + offset; 

            transform.LookAt(player.transform.position);
            }
            else
            {
                transform.position = player.transform.position + offset; 
            }
        }
        else
        {
           if(Input.GetMouseButton(1))
           {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseS, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * mouseS, Vector3.left) * offset;
            transform.position = player.transform.position + offset; 
          
            transform.LookAt(player.transform.position);
            }
            else
            { 
                transform.position = player.transform.position + offset; 
            } 
        }
    }
}
