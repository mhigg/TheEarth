using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeRote : MonoBehaviour
{
    /* public */
    public static int time;                     // 制限時間
    public Vector3 pos;                // 座標
    public GameObject Sun;
    public RectTransform earthTimer;    // 秒針の画像

    /* private */
    //private float pi;                  // 円周率
    private float theta;                // ∠Θ
    private Vector2 vec;                // ﾀｲﾏｰ軸から秒針のﾍﾞｸﾄﾙ
    private float length;
    private float lange;

    // Start is called before the first frame update
    void Start()
    {
        time = 60 * 60;    // 60fps * 60秒分
        earthTimer = GameObject.Find("Earth").GetComponent<RectTransform>();
        pos = this.gameObject.transform.position/*new Vector3(150, 1030, 0)*/;
        earthTimer.localPosition = pos;
        //pi = 3.141592654f;
        length = 100;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!mainScene.EndFlag)
        {
            lange = Mathf.Sqrt(Mathf.Pow((pos.x - Sun.transform.position.x), 2) + Mathf.Pow((pos.y - Sun.transform.position.y), 2));
            vec = new Vector2(earthTimer.position.x - /*575*/Sun.transform.position.x, earthTimer.position.y - /*660*/Sun.transform.position.y);
            earthTimer.transform.position = pos;
            theta = Mathf.Atan2(vec.y, vec.x);

            float vx = (1.0f / 12.0f) * Mathf.Cos(theta - Mathf.PI / 2);//速度を分配(X方向)
            float vy = (1.0f / 12.0f) * Mathf.Sin(theta - Mathf.PI / 2);//速度を分配(Y方向)

            if (time <= 0)
            {
                // ゲーム終了・シーンを渡す
            }

            //if (lange > length)
            //{
            //    Vector3 posVec = pos / lange;
            //    pos = new Vector3(Sun.transform.position.x/*560*/, Sun.transform.position.y/*660*/, 0) + posVec * length;
            //}

            pos.x -= vx;
            pos.y -= vy;
        }

        time--;
    }
}
