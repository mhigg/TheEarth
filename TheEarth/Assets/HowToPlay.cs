using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour
{
    public Canvas limit;
    public Canvas population;
    public Canvas timer;
    public Canvas news;

    // Start is called before the first frame update
    void Start()
    {
        CountPopulation.population = 7700000;
        limit.gameObject.SetActive(true);
        population.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        news.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // クリックするたびにCanvasを１つずつ表示していく
    }
}
