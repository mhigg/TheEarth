using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroMove : MonoBehaviour
{
    private int moveCnt;
    // Start is called before the first frame update
    void Start()
    {
        moveCnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if((moveCnt > (60*85))||(Input.GetMouseButtonDown(0)))
        {
            SceneManager.LoadScene("mainScene");
        }
        moveCnt++;
    }
}
