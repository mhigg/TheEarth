using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class News : MonoBehaviour
{
    private bool newsON = false;
    public Image borderImage;
    public Image graphicBorderImage;
    public Image graphicImage;

    private Sprite[] imageSprite;

    public GameObject reporterNameMesh = null;
    public GameObject textMesh = null;

    public float timerMax = 3.0f;
    private float timerCount = 0.0f;

    private Text reporterNameText;
    private Text textText;

    private string reporterName;
    private string text;

    private float newsImageShow;

    private void Start()
    {
        reporterNameText = reporterNameMesh.GetComponent<Text>();
        textText = textMesh.GetComponent<Text>();
        
        imageSprite[0] = Resources.Load<Sprite>("one");
        imageSprite[1] = Resources.Load<Sprite>("two");
        imageSprite[2] = Resources.Load<Sprite>("three");
        imageSprite[3] = Resources.Load<Sprite>("four");
        imageSprite[4] = Resources.Load<Sprite>("five");
        imageSprite[5] = Resources.Load<Sprite>("six");

        reporterName = "";
        text = "";
        reporterNameText.text = reporterName;
        textText.text = text;

        reporterNameText.enabled = false;
        textText.enabled = false;
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
        }

        borderImage.fillAmount = newsImageShow;
        graphicBorderImage.fillAmount = newsImageShow;
        graphicImage.fillAmount = newsImageShow;


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newsSwitch(true);
            newsGenerator(0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newsSwitch(false);
        }
    }

    public void newsSwitch(bool switchi)
    {
        newsON = switchi;
        timerCount = timerMax;
    }

    private void newsGenerator(int number)
    {
        //graphicImage.sprite = Resources.Load<Sprite>("one");
        switch (number)
        {
            case 0:
                reporterName = "NASA";
                text = "地球の自転が不明な原因で止まりました！";
                break;
            case 1:
                reporterName = "";
                text = "";
                break;
            case 2:
                reporterName = "";
                text = "";
                break;
            case 3:
                reporterName = "";
                text = "";
                break;
            default:
                reporterName = "メリー君";
                text = "これは地球が人間に対しての裁きだ。";
                break;
        }
    }
}
