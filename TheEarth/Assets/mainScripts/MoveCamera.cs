using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Earth;
    private Vector3 zAjust = new Vector3(0, 0, -320);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.transform.LookAt(Earth.transform);
//        Camera.transform.position = Earth.transform.position + zAjust;
    }
}
