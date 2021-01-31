using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityMovementAI;

public class Teleport : MonoBehaviour
{
    private FleeUnit rabbit;
    public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Rabbit")
        {
            rabbit = other.GetComponent<FleeUnit>();
            if (rabbit.goingToHole)
            {
                rabbit.goingToHole = false;
                other.transform.position = destination.position;
            }
        }
    }
}
