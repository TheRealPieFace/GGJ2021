﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Light lantern;
    public Light lanternPoint;
    public float lightFuel = 1f;
    public float degradeSpeed = .05f;
    public float lanternRunout = 1f;
    public float maxFuel;
    private float maxPointIntensity;
    public GameObject[] Rabbits;
    public Text rabbitCounter;
    private int rabbitsCaught;
    public int numberOfRabbits;
    public int firefliesCaught;
    public float timeToWinGame;
    public Text firefliesCaughttxt;
    public Text timetoWintxt;
    GameObject clone;
    public GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        maxPointIntensity = lanternPoint.intensity;
        maxFuel = maxFuel - 35;
        CountRabbits();
    }

    // Update is called once per frame
    void Update()
    {
        timeToWinGame += Time.deltaTime;
        DegradeLight();
        rabbitCounter.text = rabbitsCaught + "/" + numberOfRabbits.ToString();
    }

    void DegradeLight()
    {
        lantern.spotAngle = lightFuel * maxFuel + 35;
        lanternPoint.intensity = lightFuel * maxPointIntensity;
        lightFuel -= degradeSpeed * Time.deltaTime;
        if (lightFuel <= 0)
        {
            lightFuel = 0;
            lantern.intensity -= 5 * Time.deltaTime;
        }
    }


    public void AddFuel(float fuelAmount)
    {
        firefliesCaught += 1;
        lantern.intensity = 70;
        if (lightFuel + fuelAmount < 1)
        {
            lightFuel += fuelAmount;
        } else
        {
            lightFuel = 1;
        }

    }

    public void CountRabbits()
    {
        Rabbits = GameObject.FindGameObjectsWithTag("Rabbit");
        numberOfRabbits = Rabbits.Length;
        

    }

    public void CatchRabbit()
    {
        rabbitsCaught += 1;

        if(rabbitsCaught == numberOfRabbits)
        {
            clone = Instantiate(winScreen);
            firefliesCaughttxt.text = firefliesCaught.ToString();
            timetoWintxt.text = timeToWinGame.ToString();
           
        }
    }

   
}
