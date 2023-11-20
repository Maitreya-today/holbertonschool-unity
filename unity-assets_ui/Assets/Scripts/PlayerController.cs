using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // reference to our player controller
    public CharacterController player;  
    public float speed = 12f; 
    public float gravity = 18f;
    public float jumpH = 9f;
    public Transform camera;
    Vector3 velocity;
    private Vector3 move = Vector3.zero;
    private float alt;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded)
        {      
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move);
        
        move = camera.right * move.x + camera.forward * move.z;
        move.y = 0f;
        move *= speed;
            
            if (Input.GetButtonDown("Jump"))
            {
                move.y = jumpH;
            }
        }
        else
        {
            float initj = move.y;
            // Debug.Log("move.y " + move.y);
            // Debug.Log("initj" + initj);
            move = new Vector3(Input.GetAxis("Horizontal"), move.y, Input.GetAxis("Vertical"));
            move = camera.right * move.x + camera.forward * move.z;
            
            
            
            move = transform.TransformDirection(move);
            move.y = initj;
            // Debug.Log("initj2 " + initj);
            // Debug.Log("movey2 " + move.y);

            move.x *= speed;
            move.z *= speed;
            //Debug.Log("y" + y);
            //Debug.Log("move.y" + move.y);
            
        }
        
        move.y += gravity * Time.deltaTime;

        player.Move(move * Time.deltaTime);

        if (player.transform.position.y < -10)
        {
            transform.position = new Vector3(0, 20, 0);
        }
        
    }
}
