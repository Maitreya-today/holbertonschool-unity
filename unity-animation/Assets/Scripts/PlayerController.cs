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
    Animator anim;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        //player = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded)
        {      
        anim.SetBool("ground", true);
        anim.SetBool("falling", false);
        anim.SetBool("Run", false);
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        // Vector3 movedir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.zero;
        // player.Move(movedir.normalized * speed * Time.deltaTime);
        //Debug.Log("movedir" + movedir);
        //move = transform.TransformDirection(move);
        
        move = camera.right * move.x + camera.forward * move.z;
        move.y = 0f;
        move *= speed;
            
            if (Input.GetButtonDown("Jump"))
            {
                move.y = jumpH;
                anim.SetTrigger("Jump");
            }
        }
        else
        {
            float initj = move.y;
    
            move = new Vector3(Input.GetAxis("Horizontal"), move.y, Input.GetAxis("Vertical"));
        //     float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
        // float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        // transform.rotation = Quaternion.Euler(0f, angle, 0f);

       
        //move = transform.TransformDirection(move);
           
            move = camera.right * move.x + camera.forward * move.z;
            
            
            //move = transform.TransformDirection(move);
            move.y = initj;

            move.x *= speed;
            move.z *= speed;
            
        }
        
        move.y += gravity * Time.deltaTime;

        player.Move(move * Time.deltaTime);

        if (player.transform.position.y < -10)
        {
            transform.position = new Vector3(0, 30, 0);
           // anim.SetTrigger("fall");
            anim.SetBool("Run",true);
            anim.SetBool("ground",false);
            anim.SetBool("falling",true);
            Debug.Log("falling");
        }

        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            anim.SetBool("Run",true);
        }
        else
        {
            //anim.SetBool("Run",false);   
        }
    }
}
