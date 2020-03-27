using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainScene : MonoBehaviour
{
    public static bool EndFlag;
    bool clearFlag;

    // Start is called before the first frame update
    void Start()
    {
        EndFlag = false;
        clearFlag = false;

        CountPopulation.population = 7700000;
    }

    // Update is called once per frame
    void Update()
    {
        if (CountPopulation.population <= 0)
        {
            EndFlag = true;
        }

        if (TimeRote.time < 0)
        {
            clearFlag = true;
        }

        if(clearFlag)
        {
            ChangeGameClearScene();
        }

        if (EndFlag)
        {
            Invoke("ChangeGameOverScene", 5.0f);
        }
    }
    void ChangeGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    void ChangeGameClearScene()
    {
        SceneManager.LoadScene("GameClear");
    }
}
