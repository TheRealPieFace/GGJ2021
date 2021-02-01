using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyRoam : MonoBehaviour
{
    public float radius = 3;
    public float speed = 3;
    public float jitter = .5f;
    private Vector3 center;
    private Vector3 currentDestination;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
        height = transform.position.y;
        PickDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x == currentDestination.x && transform.position.z == currentDestination.z)
        {
            PickDestination();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, currentDestination + new Vector3(0, Random.Range(-jitter, jitter), 0),  Time.deltaTime * speed);
        }
    }

    private void PickDestination()
    {
        var randomX = Random.Range(center.x - radius, center.x + radius);
        var randomZ = Random.Range(center.z - radius, center.z + radius);
        currentDestination = new Vector3(randomX, height, randomZ);
    }
}
