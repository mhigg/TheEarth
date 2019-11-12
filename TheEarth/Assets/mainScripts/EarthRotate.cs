using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotate : MonoBehaviour
{
   public static float speed;
   
    Vector3 startMousePos;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;
        if (!mainScene.EndFlag)
        {
            //マウス
            float moveDistance = 0.0f;     // 正規化されたﾏｳｽの移動距離
            if (Input.GetMouseButtonDown(0))
            {
                startMousePos = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                moveDistance = (startMousePos.x - Input.mousePosition.x) / Screen.height;
            }
            float velocity = 10.0f;
            velocity *= moveDistance;
            speed += velocity;

            // ｷｰﾎﾞｰﾄﾞ
            if (Input.GetKey(KeyCode.UpArrow))
            {
                speed -= 0.5f;
            }

            if (Input.GetKey(KeyCode.Delete))
            {
                speed += 0.5f;
            }
            else if (speed > 0.0f)
            {
                speed = 0.0f;
            }

            // 速度減衰
            speed += 0.2f;
            // 限界値設定
            if (speed < -100)
            {
                speed = -100;
            }
            if (speed > 0)
            {
                speed = 0;
            }
            // 現在の回転量へ加算する
            myTransform.Rotate(0.0f, speed, 0.0f/*, Space.World*/);
        }
    }
}
