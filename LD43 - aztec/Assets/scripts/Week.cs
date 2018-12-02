using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Week : MonoBehaviour {

    public GameObject night;
    public GameObject dusk;

    private Image nightImg;
    private Image duskImg;
    private AudioSource thunder;

    private int dayOfWeek = 0;

    public bool isSunday = false;
    public float dayLength = 180f;
    public float timeScale = 1f;
    public float dayTime = 0f;
    public float maxOpacity = .75f;
    public float scaledAlpha;

    public GameObject[] days;

    private void Start()
    {
        thunder = GetComponent<AudioSource>();
        for (int i = 1; i < 6; i++) days[i].SetActive(false);
        nightImg = night.GetComponent<Image>();
        duskImg = dusk.GetComponent<Image>();
        nightImg.color = new Color(nightImg.color.r, nightImg.color.g, nightImg.color.b, 0f);
        duskImg.color = new Color(duskImg.color.r, duskImg.color.g, duskImg.color.b, 0f);
        StartCoroutine("WeekLoop");
    }

    IEnumerator WeekLoop()
    {
        while(true)
        {
            dayTime += Time.deltaTime * timeScale;
            if(dayTime > dayLength * 0.75f && dayTime < dayLength * 0.9f && scaledAlpha < maxOpacity)
            {
                scaledAlpha += timeScale / (dayLength * 5);
                nightImg.color = new Color(nightImg.color.r, nightImg.color.g, nightImg.color.b, scaledAlpha);
            }
            if(dayTime > dayLength * 0.1f && dayTime < dayLength * 0.25f && scaledAlpha > 0)
            {
                scaledAlpha -= timeScale / (dayLength*5);
                nightImg.color = new Color(nightImg.color.r, nightImg.color.g, nightImg.color.b, scaledAlpha);
            }
            if(dayTime > dayLength)
            {
                dayTime = 0f;
                dayOfWeek++;
                Color temp = nightImg.color;
                nightImg.color = new Color(1f, 1f, 1f, 0.75f);
                thunder.Play();
                yield return new WaitForSeconds(.1f);
                nightImg.color = new Color(temp.r, temp.g, temp.b, scaledAlpha);
                days[dayOfWeek].SetActive(true);
            }
            if(dayOfWeek == 6)
            {
                isSunday = true;
            }
            if(dayOfWeek > 6)
            {
                for (int i = 1; i < 6; i++) days[i].SetActive(false);
                dayOfWeek = 0;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
