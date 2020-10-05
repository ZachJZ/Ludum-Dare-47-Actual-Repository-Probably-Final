using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TimerScript : MonoBehaviour
{
    float maxTime;
    float liveTimer;
    bool isTimerGoing;
    int intTime;

    HeroScript myHero;

    Text myText;

    void Start()
    {
        if (maxTime == 0)
        {
            maxTime = 20;
        }

        myText = gameObject.GetComponentInChildren<Text>();

        resetTimer();
        StartTimer(true);

        myHero = FindObjectOfType<HeroScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isTimerGoing)
        {
            liveTimer -= Time.deltaTime;
            intTime = Mathf.RoundToInt(liveTimer);
        }

        if (liveTimer <= 0)
        {
            isTimerGoing = false;
            liveTimer = 0;
            //play end sound
            myHero.SetTimerDone();
        }

        appendTimer();
    }

    public void ResetDay()
    {
        resetTimer();
        StartTimer(true);
    }

    public void resetTimer()
    {
        liveTimer = maxTime;
    }

    public void StartTimer(bool isGoing)
    {
        isTimerGoing = isGoing;
    }

    void appendTimer()
    {
        myText.text = "Time: " + intTime;
    }
}
