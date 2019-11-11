using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mainEndMng.EndFlag)
        {
            Invoke("ChangeScene", 5.0f);
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
