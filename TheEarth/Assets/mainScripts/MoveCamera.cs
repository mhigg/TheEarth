using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Earth;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Camera.transform.RotateAround(Earth.transform.position, Vector3.down, Time.deltaTime * 20.0f);

        Camera.transform.LookAt(Earth.transform);
    }
}
