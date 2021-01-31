using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyInteraction : MonoBehaviour
{
    private GameManager gameManager;
    public float fuelPercentIncrease = .5f;
    public GameObject spawner;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Interact()
    {
        gameManager.AddFuel(fuelPercentIncrease);
        spawner.GetComponent<SpawnFirefly>().StartCounting();
        Destroy(this.gameObject);
    }
}
