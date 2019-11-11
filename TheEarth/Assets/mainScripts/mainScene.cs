using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainScene : MonoBehaviour
{
    public static bool EndFlag;

    // Start is called before the first frame update
    void Start()
    {
        EndFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || CountPopulation.population <= 0)
        {
            EndFlag = true;
        }
        if (EndFlag)
        {
            Invoke("ChangeScene", 5.0f);
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
