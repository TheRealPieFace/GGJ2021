using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    private List<GameObject> firefliesInRange = new List<GameObject>();
    private List<GameObject> rabbitsInRange = new List<GameObject>();
    public GameObject rabbitInteractionUI;
    public GameObject fireflyInteractionUI;


    private void Update()
    {
        if(rabbitsInRange.Count > 0)
        {
            //rabbitInteractionUI.SetActive(true);
            //fireflyInteractionUI.SetActive(false);
        } else if (firefliesInRange.Count > 0)
        {
            //fireflyInteractionUI.SetActive(true);
        } else
        {
            //rabbitInteractionUI.SetActive(false);
            //fireflyInteractionUI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(rabbitsInRange.Count > 0)
            {
                rabbitsInRange[0].GetComponentInParent<RabbitInteraction>().Interact();
                rabbitsInRange.RemoveAt(0);
            }
            else if (firefliesInRange.Count > 0)
            {
                firefliesInRange[0].GetComponent<FireFlyInteraction>().Interact();
                firefliesInRange.RemoveAt(0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Firefly")
        {
            firefliesInRange.Add(other.gameObject);
        }
        if(other.tag == "RabbitInteraction")
        {
            rabbitsInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Firefly")
        {
            firefliesInRange.Remove(other.gameObject);
        }
        if (other.tag == "RabbitInteraction")
        {
            rabbitsInRange.Remove(other.gameObject);
        }
    }
}
