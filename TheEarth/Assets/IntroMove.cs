using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMove : MonoBehaviour
{
    private int moveCnt;    // 経過時間(ﾌﾚｰﾑ)

    // Start is called before the first frame update
    void Start()
    {
        moveCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 85秒経過または左ｸﾘｯｸ
        if((moveCnt > (60*85))||(Input.GetMouseButtonDown(0)))
        {
            SceneManager.LoadScene("HowToScene");    // 操作説明ｼｰﾝに移行
        }
        moveCnt++;
    }
}
