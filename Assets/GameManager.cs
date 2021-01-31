using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Light lantern;
    public Light lanternPoint;
    public float lightFuel = 1f;
    public float degradeSpeed = .05f;
    public float lanternRunout = 1f;
    public float maxFuel;
    private float maxPointIntensity;

    // Start is called before the first frame update
    void Start()
    {
        maxPointIntensity = lanternPoint.intensity;
        maxFuel = maxFuel - 35;
        //lightFuel = maxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        DegradeLight();
    }

    void DegradeLight()
    {
        lantern.spotAngle = lightFuel * maxFuel + 35;
        lanternPoint.intensity = lightFuel * maxPointIntensity;
        lightFuel -= degradeSpeed * Time.deltaTime;
        if (lightFuel <= 0)
        {
            lightFuel = 0;
            StartCoroutine(TurnOffLight());
        }
    }

    IEnumerator TurnOffLight()
    {
        yield return new WaitForSeconds(lanternRunout);
        CheckLantern();
    }

    void CheckLantern()
    {
        if (lightFuel <= 0)
        {
            lantern.intensity = 0;
        }
    }

    public void AddFuel(float fuelAmount)
    {
        lantern.intensity = 25;
        if(lightFuel + fuelAmount < 1)
        {
            lightFuel += fuelAmount;
        } else
        {
            lightFuel = 1;
        }
        
    }
}
