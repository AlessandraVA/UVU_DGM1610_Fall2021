using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isFollowing;
    public float followSpeed;
    public Transform followTarget;

    

    // Update is called once per frame
    void Update()
    {
        if(isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);

            print("You Got The Key To Unlock The Den, Hurry And Get Back Home!");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(!isFollowing)
            {
                PlayerController thePlayer = FindObjectOfType<PlayerController>();
                followTarget = thePlayer.keyFollowPoint;
                isFollowing = true;
                thePlayer.followingKey = this;
            }
        }
    }
}
