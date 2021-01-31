using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyInteraction : MonoBehaviour
{
    private GameManager gameManager;
    public float fuelPercentIncrease = .5f;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Interact()
    {
        gameManager.AddFuel(fuelPercentIncrease);
        //GetComponentInParent<SpawnFirefly>().StartTimer();
        //Destroy(this.GameObject);
        
    }
}
