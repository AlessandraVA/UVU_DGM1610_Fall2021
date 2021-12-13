using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float currentime = 0f;
    public float starttime;
    public TMP_Text timertext;


    // Start is called before the first frame update
    void Start()
    {
        currentime = starttime;
    }

    // Update is called once per frame
    void Update()
    {
        currentime -= 1 * Time.deltaTime;
        timertext.text = "Timer: " + currentime.ToString("0");
        if(currentime<=0)
        {
            currentime = 0;
        }

    }
}
