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
            newsGenerator(4);
            newsSwitch(true);
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
        GameObject imageObject = GameObject.Find("Image" + (number + 1));
        if (imageObject != null)
        {
            graphicImage = imageObject.GetComponent<Image>();
        }
        switch (number)
        {
            case 0:
                reporterName = "";
                text = "";
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
            case 4:
                reporterName = "NASA";
                text = "地球の自転が不明な原因で止まりました!";
                break;
            default:
                reporterName = "メリー君";
                text = "これは地球が人間に対しての裁きだ。";
                break;
        }
    }
}
