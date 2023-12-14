using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    //================================================================================
    // Public Variables ==============================================================
    //================================================================================
    public Transform target;

    //================================================================================
    // Private Variables ==============================================================
    //================================================================================
    private bool isInverted;
    private const float turn_speed = 150f;
    private const float vert_speed = 150f;
    //private int inverted = 1;
    private Quaternion rotation;
    private Vector3 cameraRotation;
    private Vector3 offset = new Vector3(0f, 2.5f, -6.25f);



    //================================================================================
    // Start is called before the first frame update =================================
    //================================================================================
    void Start()

    {
        setCameraTarget(target);
        if (PlayerPrefs.GetInt("isInverted") == 1)
            isInverted = true;
        else
            isInverted = false;
    }

    //================================================================================
    // Update is called once per frame ===============================================
    //================================================================================
    void FixedUpdate()
    {
        // Vertical Movement
        rotation = Quaternion.identity;
        if (isInverted && Input.GetKey(KeyCode.Mouse1))
            rotation = Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * vert_speed * Time.deltaTime, Vector3.right);
        else if (Input.GetKey(KeyCode.Mouse1))
            rotation = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * vert_speed * Time.deltaTime, Vector3.right);
        offset = rotation * offset;
        transform.position = target.position + offset;

        // Horizontal Movement
        if (Input.GetKey(KeyCode.Mouse1))
            rotation = Quaternion.AngleAxis(-Input.GetAxis("Mouse X") * turn_speed * Time.deltaTime, Vector3.up);
        //else
        //    rotation = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turn_speed * Time.deltaTime, Vector3.up);

        offset = rotation * offset;
        transform.position = target.position + offset;
        transform.LookAt(target);
    }

    //================================================================================
    // Coroutines & Other Functions ==================================================
    //================================================================================

    // Sets the target for the camera
    public void setCameraTarget(Transform t)
    {
        if (t != null)
            target = t;
        else
            Debug.LogError("Men comportsese");
    }
}
