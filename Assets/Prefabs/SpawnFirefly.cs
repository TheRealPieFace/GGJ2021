﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFirefly : MonoBehaviour
{
    public float timetospawn;
    float timer;
    public GameObject Firefly;
    GameObject clone;
    public bool startcounting = false;
   

    public void StartCounting()
    {
        startcounting = true;
        timer = timetospawn;
    }

    void Update()
    {
        if (startcounting)
        {
            if (timetospawn > 0)
            {
                timetospawn -= Time.deltaTime;
            }

            if (timetospawn <= 0)
            {
                Spawn();
                startcounting = false;
            }
        }
    }

    public void Spawn()
    {
        clone = Instantiate(Firefly, transform.position, Quaternion.identity);
    }

    public void Start()
    {
        Spawn();
    }
}
