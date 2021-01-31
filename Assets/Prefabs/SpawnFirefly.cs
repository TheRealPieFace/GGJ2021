using System.Collections;
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
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            if (timer <= 0)
            {
                Spawn();
                startcounting = false;
            }
        }
    }

    public void Spawn()
    {
        clone = Instantiate(Firefly, transform.position, Quaternion.identity);
        clone.GetComponent<FireFlyInteraction>().spawner = gameObject;
    }

    public void Start()
    {
        Spawn();
    }
}
