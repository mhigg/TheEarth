using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject _timer = null;
    public GameObject _miniTimer = null;
    public GameObject _realTimer = null;
    private Text worldTime;
    private Text localTime;
    private Text realTime;

    //初期時間
    public int initialYear = 2019;
    public int initialMonth = 11;
    public int initialDay = 8;
    //現在時間
    private int currentYear;
    private int currentMonth;
    private int currentDay;
    //経過時間
    private int passedYear;
    private int passedMonth;
    private int passedDay;

    //速度
    public double dayPerFrame = 0.01;

    //リアルタイム
    private int secondTimer;
    private int minuteTimer;

    //タイマー
    private double simulateTimer;
    private double realTimer;

    //スイッチ
    private bool timerSwitch;
    
    void Start()
    {
        worldTime = _timer.GetComponent<Text>();
        localTime = _miniTimer.GetComponent<Text>();
        realTime = _realTimer.GetComponent<Text>();

        currentYear = initialYear;
        currentMonth = initialMonth;
        currentDay = initialDay;

        simulateTimer = 0.0f;
        realTimer = 0.0f;

        timerSwitch = true;
    }
    
    void Update()
    {
        //calculation
        if (timerSwitch)
        {
            //シムレイションタイム
            if ((simulateTimer += Time.deltaTime) >= dayPerFrame)
            {
                simulateTimer = 0;
                dayUpdate();
            }
            //リアルタイム
            if ((realTimer += Time.deltaTime) > 1)
            {
                realTimer = 0;
                SecondUpdate();
            }
        }

        //draw
        worldTime.text = "西暦  " + currentYear + "年　" + currentMonth + "月　" + currentDay + "日";
        localTime.text = "経過時間:" + passedYear + "年" + passedMonth + "月" + passedDay + "日";
        realTime.text = "[" + minuteTimer + "分" + secondTimer + "秒]";
    }

    private void dayUpdate()
    {
        //一日が経った
        if ((currentDay++) >= 31)
        {
            currentDay = 1;
            passedDay = 1;
            if ((currentMonth++) >= 12)
            {
                passedMonth = 1;
                passedYear++;
                currentMonth = 1;
                currentYear++;
            }
            else
            {
                passedMonth++;
            }
        }
        else
        {
            passedDay++;
        }
    }

    private void SecondUpdate()
    {
        //一秒が経った
        if ((secondTimer++) >= 60)
        {
            secondTimer = 0;
            minuteTimer++;
        }
    }

    public void TimerSwitch(bool switchi)
    {
        timerSwitch = switchi;
    }
}
