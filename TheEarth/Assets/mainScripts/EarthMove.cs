using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMove : MonoBehaviour
{
    //private float speed;
    private float radius;
    float frame;
    float x;
    float y;
    float z;

    // Use this for initialization
    void Start()
    {
        frame = 0;
        //speed = -6.0f;
        radius = -800.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!mainScene.EndFlag)
        {
            x = radius * Mathf.Sin((-frame / 10.0f) * (Mathf.PI / 180));
            y = 0;
            z = radius * Mathf.Cos((-frame / 10.0f) * (Mathf.PI / 180));

            frame += Time.deltaTime;
            transform.position = new Vector3(x, y, z);
        }
    }
}
