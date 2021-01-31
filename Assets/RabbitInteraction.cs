using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitInteraction : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Interact()
    {
        //gameManager.CatchRabbit();
        Debug.Log("Catch Rabbit");
        Destroy(this.gameObject);
    }
}
