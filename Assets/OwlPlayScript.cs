using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlPlayScript : MonoBehaviour
{
    bool waiting = false;
    float waitTime = 0;
    float timer = 0;

    void Update()
    {
        if (!waiting)
        {
            waitTime = Random.Range(30, 120);
            waiting = true;
        }
        else
        {
            timer += Time.deltaTime;
            if(timer >= waitTime)
            {
                this.GetComponent<AudioSource>().Play();
                waiting = false;
                timer = 0;
            }
        }
    }
}
