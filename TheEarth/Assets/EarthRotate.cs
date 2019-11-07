using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotate : MonoBehaviour
{
    Vector3 speed;
    // Start is called before the first frame update
    void Start()
    {
       speed = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;
        
        if(Input.GetKey(KeyCode.UpArrow))
        {
            speed.y -= 0.5f;
        }
        else if(speed.y < 0)
        {
            speed.y += 0.2f;
        }
        
        if (Input.GetKey(KeyCode.Delete))
        {
            speed.y += 0.5f;
        }
        else if (speed.y > 0.0f)
        {
            speed.y = 0.0f;
        }
        // ワールド座標基準で、現在の回転量へ加算する
        
        myTransform.Rotate(0.0f, speed.y, 0.0f, Space.World);
    }
}
