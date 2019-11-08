using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Earth;

    private float pubRadius;
    private float myRadius;
    private float angleLate;

    // Start is called before the first frame update
    void Start()
    {
        //        Camera.transform.position = Earth.transform.position;
        pubRadius = -1330.0f;
        myRadius = -(Camera.transform.localPosition - Earth.transform.localPosition).magnitude;
        angleLate = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            angleLate += 1.0f;
            float angle2 = (angleLate * (Mathf.PI / 180.0f));
            Camera.transform.position = new Vector3(
                myRadius * Mathf.Sin(angle2),
                Camera.transform.position.y,
                myRadius * Mathf.Cos(angle2));
        }

        float angle = ((-Time.frameCount / 10.0f) * (Mathf.PI / 180.0f));
        Camera.transform.position = new Vector3(
            pubRadius * Mathf.Sin(angle),
            Camera.transform.position.y,
            pubRadius * Mathf.Cos(angle));

        Camera.transform.LookAt(Earth.transform);
    }
}
