﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountPopulation : MonoBehaviour
{
    public GameObject popObject = null;
    public static int population = 7700000;
    public int randomizeRange = 500;

    public static int enviromentLevel = 0;    //環境が生物に厳しいほど低く、優しいほど高い、人口の計算し方に影響を与える
    private void Start()
    {
        population = 7700000;
    }
    // Update is called once per frame
    void Update()
    {
        Text popText = popObject.GetComponent<Text>();
        popText.text = (population / 1000000).ToString() + "," +
            ((population / 1000) % 1000).ToString() + "," +
            (population % 1000).ToString();

        int decreaseRange = randomizeRange;
        int increaseRange = randomizeRange;

        if (enviromentLevel < 0) decreaseRange *= -enviromentLevel;
        if (enviromentLevel > 0) increaseRange *= enviromentLevel;

        int populationManipulate = Random.Range(-decreaseRange, increaseRange);
        population += populationManipulate;

        if (Mathf.Abs(50.0f + EarthRotate.speed) > 15.0f)
        {
            ManipulateEnviromentLevel(((int)Mathf.Abs(50 + EarthRotate.speed)) * -5);
        }
        else if (Mathf.Abs(50.0f + EarthRotate.speed) < 15.0f)
        {
            ManipulateEnviromentLevel(180 - ((int)Mathf.Abs(50 + EarthRotate.speed)) * 5);
        }
        if(population < 0)
        {
            population = 0;
        }
        if (mainScene.EndFlag)
        {
            population = 0;
        }

//Text spDebug = popObject.GetComponent<Text>();
//spDebug.text = EarthRotate.speed.ToString();
    }
    //環境レベルを変わる
    public void ManipulateEnviromentLevel(int newLevel)
    {
        enviromentLevel = newLevel;
    }

    //人口を無理やり変える
    public void ManipulatePopulation(int newPopulation)
    {
        population = newPopulation;
    }

    //人口を直接減らす
    public void DecreasePopulation(int value)
    {
        population -= value;
    }

    //人口を直接増やす
    public void IncreasePopulation(int value)
    {
        population += value;
    }
}
