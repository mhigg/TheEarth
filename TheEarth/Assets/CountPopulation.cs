using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountPopulation : MonoBehaviour
{
    public GameObject popObject = null;
    public int billion;

    // Start is called before the first frame update
    void Start()
    {
        billion = 770000;
    }

    // Update is called once per frame
    void Update()
    {
        int bilTop = billion / 10000;
        int bilBottom = billion - bilTop * 10000;

        Text popText = popObject.GetComponent<Text>();
        popText.text = bilTop.ToString() + "億" + bilBottom.ToString();

        billion--;
    }
}
