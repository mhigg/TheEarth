using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPopulation : MonoBehaviour
{
    public GameObject popObject = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text popText = popObject.GetComponent<Text>();
        popText.text = CountPopulation.population.ToString() /*bilTop.ToString() + "億" + bilBottom.ToString()*/;
    }
}
