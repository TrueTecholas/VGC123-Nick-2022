using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject waypoint1;
    public GameObject waypoint2;
    public float speed = 5;

    private float direction = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Vector3.right * Time.deltaTime;

        // If you are close to waypoint 1 move right
        if (Mathf.Abs(waypoint1.transform.position.x - transform.position.x) < 0.1f)
        {
            direction = 1;
        }
        // If you are close to waypoint 1 move left
        if (Mathf.Abs(waypoint2.transform.position.x - transform.position.x) < 0.1f)
        {
            direction = -1;
        }
    }
}
