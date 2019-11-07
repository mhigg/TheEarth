using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMove : MonoBehaviour
{
    private float speed;
    private float radius;
    float x;
    float y;
    float z;

    // Use this for initialization
    void Start()
    {
        speed = -0.5f;
        radius = -800.0f;
    }

    // Update is called once per frame
    void Update()
    {
        x = radius * Mathf.Sin(Time.time * speed);
        y = 0;
        z = radius * Mathf.Cos(Time.time * speed);

        transform.position = new Vector3(x, y, z);
    }
}
