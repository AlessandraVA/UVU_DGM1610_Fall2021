using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        // Makes the carrot launcher move straight up when I shoot with the space bar
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
