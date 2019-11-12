using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class News : MonoBehaviour
{
    private bool newsON = false;
    public Image borderImage;
    public Image graphicBorderImage;
    private Image graphicImage;

    public GameObject reporterNameMesh = null;
    public GameObject textMesh = null;
    
    public float timerMax = 3.0f;
    private float timerCount = 0.0f;

    private Text reporterNameText;
    private Text textText;

    private string reporterName;
    private string text;

    private float newsImageShow;

    private int msgCnt; // ﾒｯｾｰｼﾞ表示用ｶｳﾝﾄ

    public AudioClip morse;
    public AudioSource audioMorse;
    private void Start()
    {
        reporterNameText = reporterNameMesh.GetComponent<Text>();
        textText = textMesh.GetComponent<Text>();
        
        reporterName = "";
        text = "";
        reporterNameText.text = reporterName;
        textText.text = text;

        reporterNameText.enabled = false;
        textText.enabled = false;

        GameObject imageObject = GameObject.Find("Image2");
        if (imageObject != null)
        {
            graphicImage = imageObject.GetComponent<Image>();
        }

        msgCnt = 0;
        audioMorse = GetComponent<AudioSource>();
    }

    private void Update()
    {
        reporterNameText.enabled = newsON;
        textText.enabled = newsON;
        if (newsON)
        {
            if (newsImageShow < 1)
            {
                newsImageShow += 0.2f;
            }

            if (newsImageShow >= 1)
            {
                reporterNameText.text = "「" + reporterName + "」";
                textText.text = text;
                if ((timerCount -= Time.deltaTime) <= 0.0f)
                {
                    newsON = !newsON;
                }
            }
        }
        else if (!newsON)
        {
            if (newsImageShow > 0)
            {
                newsImageShow -= 0.2f;
            }

            if (msgCnt % (60 * 5) == 0)
            {
                if (EarthRotate.speed >= 0)
                {
                    newsGenerator(4);
                    newsSwitch(true);
                }
                else if (Mathf.Abs(50.0f + EarthRotate.speed) < 15.0f)
                {
                    newsGenerator(1);
                    newsSwitch(true);
                }
                else if (Mathf.Abs(50.0f + EarthRotate.speed) > 15.0f)
                {
                    newsGenerator(0);
                    newsSwitch(true);
                }
            }
            else if (msgCnt % (60 * 7) == 0)
            {
                newsGenerator(2);
                newsSwitch(true);
            }
            else if (msgCnt % (60 * 11) == 0)
            {
                newsGenerator(3);
                newsSwitch(true);
            }
        }

        borderImage.fillAmount = newsImageShow;
        graphicBorderImage.fillAmount = newsImageShow;
        graphicImage.fillAmount = newsImageShow;


        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    newsGenerator(Random.Range(0,4));
        //    newsSwitch(true);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    newsSwitch(false);
        //}
        msgCnt++;
    }

    public void newsSwitch(bool switchi)
    {
        newsON = switchi;
        timerCount = timerMax;
    }

    private void newsGenerator(int number)
    {
        GameObject imageObject = GameObject.Find("Image" + (number + 1));
        if (imageObject != null)
        {
            graphicImage = imageObject.GetComponent<Image>();
        }
        switch (number)
        {
            case 0:
                reporterName = "山田";
                text = "アカンこのままじゃ地球が滅亡ぅ！";
                break;
            case 1:
                reporterName = "六号";
                text = "三島殿、今日は快適でござるよ！";
                break;
            case 2:
                reporterName = "テラ";
                text = "ウイイイイイイイッッッッス";
                CountPopulation.increceLevel = 4;
                CountPopulation.DecreaceLevel = 2;
                break;
            case 3:
                reporterName = "M@STER";
                text = "ちくわ大明神";
                CountPopulation.increceLevel = 0;
                CountPopulation.DecreaceLevel = 5;
                break;
            case 4:
                reporterName = "NASA";
                text = "緊急事態！地球の自転が停止しました！";
                CountPopulation.enviromentLevel = 10;
                break;
            default:
                reporterName = "メリー君";
                text = "これは地球が人間に対しての裁きだ。";
                break;
        }
    }
}
