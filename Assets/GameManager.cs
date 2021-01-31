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
            lantern.intensity -= 5 * Time.deltaTime;
        }
    }


    public void AddFuel(float fuelAmount)
    {
        lantern.intensity = 70;
        if(lightFuel + fuelAmount < 1)
        {
            lightFuel += fuelAmount;
        } else
        {
            lightFuel = 1;
        }
        
    }
}
