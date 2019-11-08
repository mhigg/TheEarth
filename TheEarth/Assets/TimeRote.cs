﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeRote : MonoBehaviour
{
    /* public */
    public int time;                     // 制限時間
    public Vector3 pos;                // 座標
    public GameObject Sun;
    public RectTransform earthTimer;    // 秒針の画像

    /* private */
    private float pi;                  // 円周率
    private float theta;                // ∠Θ
    private Vector2 vec;                // ﾀｲﾏｰ軸から秒針のﾍﾞｸﾄﾙ
    private float length;
    private float lange;

    // Start is called before the first frame update
    void Start()
    {
        time = 60 * 60;    // 60fps * 60秒分
        earthTimer = GameObject.Find("Earth").GetComponent<RectTransform>();
        pos = new Vector3(earthTimer.transform.position.x, earthTimer.transform.position.y, 0);
        earthTimer.localPosition = pos;
        pi = 3.141592654f;
        length = 200;

    }

    // Update is called once per frame
    void Update()
    {
        lange = Mathf.Sqrt(Mathf.Pow((pos.x- Sun.transform.position.x), 2) + Mathf.Pow((pos.y- Sun.transform.position.y), 2));
        vec = new Vector2(earthTimer.position.x - /*575*/Sun.transform.position.x, earthTimer.position.y - /*660*/Sun.transform.position.y);
        earthTimer.transform.position = pos;
        theta = Mathf.Atan2(vec.y, vec.x);

        float vx = 0.2f * Mathf.Cos(theta - pi / 2);//速度を分配(X方向)
        float vy = 0.2f * Mathf.Sin(theta - pi / 2);//速度を分配(Y方向)

        if (time <= 0)
        {
            // ゲーム終了・シーンを渡す
        }

        if (lange > length)
        {
            Vector3 posVec = pos / lange;
            pos = new Vector3(Sun.transform.position.x/*560*/, Sun.transform.position.y/*660*/, 0) + posVec * length;
        }

        pos.x -= vx;
        pos.y -= vy;

        time--;
    }
}
