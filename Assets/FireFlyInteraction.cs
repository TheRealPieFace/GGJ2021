using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyInteraction : MonoBehaviour
{
    private GameManager gameManager;
    public float fuelPercentIncrease = .5f;
    public GameObject spawner;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Interact()
    {
        audioManager.Play("Firefly");
        GameObject.FindGameObjectWithTag("FireflySound").GetComponent<AudioSource>().Play();
        gameManager.AddFuel(fuelPercentIncrease);
        spawner.GetComponent<SpawnFirefly>().StartCounting();
        Destroy(this.gameObject);
    }
}
