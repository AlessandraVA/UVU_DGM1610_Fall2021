using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed = 25.5f;
    public float turnSpeed = 50.0f;

    public float hinput;
    public float vinput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hinput = Input.GetAxis("Horizontal");
        vinput = Input.GetAxis("Vertical");
        //rotates tank left and right
        transform.Rotate(Vector3.up,turnSpeed * hinput * Time.deltaTime);
        //moves the tank forward and backwards
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vinput);
    }
}
