using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starfieldMove : MonoBehaviour
{
    float Target;
    void Start()
    {
    }

    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;
    
        // ワールド座標基準で、現在の回転量へ加算する
        myTransform.Rotate(0.0f, 0.0f, 0.01f, Space.World);

    }
}
