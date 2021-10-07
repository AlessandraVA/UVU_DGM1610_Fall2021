using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;                         // movement speed in units per second
    public float jumpforce;                        // force applied upwards

    public float lookSensitivity;                 // Mouse look sensitivity
    public float maxLookX;                       // Lowest down we can look
    public float minLookX;                      // Highest up we can look
    private float rotX;                        // Current x rotation of the camera

    private Camera camera;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //Get Components
        camera = camera.main;
        rb = GetComponent<Rigid>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    void Move()
    {
        float x = Input.GetAxis("Horizonal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);


    }
        void CamLook()
        {
            float y = Input.GetAxis("Mouse X") * lookSensitivity;
            rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
        }
}
