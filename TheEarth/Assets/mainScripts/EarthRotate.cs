using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotate : MonoBehaviour
{
    public float speed;
    bool EndFlag;
    // Start is called before the first frame update
    void Start()
    {
        //speed = new Vector3(0.0f, 0.0f, 0.0f);
        EndFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;
        if(Input.GetMouseButtonDown(0))
        {
            EndFlag = true;
        }
        if (!EndFlag)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                speed -= 0.5f;
            }
            else if (speed < 0)
            {
                speed += 0.2f;
            }

            if (Input.GetKey(KeyCode.Delete))
            {
                speed += 0.5f;
            }
            else if (speed > 0.0f)
            {
                speed = 0.0f;
            }

            if (speed < -100)
            {
                speed = -100;
            }
            // 現在の回転量へ加算する
            myTransform.Rotate(0.0f, speed, 0.0f/*, Space.World*/);
        }
    }
}
