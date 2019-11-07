using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountPopulation : MonoBehaviour
{
    public GameObject popObject = null;
    public static int population;                     // 人口

    // Start is called before the first frame update
    void Start()
    {
        population = 770000;
    }

    // Update is called once per frame
    void Update()
    {
        //int bilTop = population / 10000;
        //int bilBottom = population - bilTop * 10000;
        
        Text popText = popObject.GetComponent<Text>();
        popText.text = population.ToString() /*bilTop.ToString() + "億" + bilBottom.ToString()*/;

        population--;
    }
}
