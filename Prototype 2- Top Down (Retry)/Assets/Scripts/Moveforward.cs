using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveforward : MonoBehaviour
{

    private float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
