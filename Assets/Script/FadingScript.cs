using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingScript : MonoBehaviour
{
    public GameObject FadeScreen;

    bool fadedOut;

    void Start()
    {
        fadedOut = false;
    }

    public void Fade2Clear()
    {
        if (fadedOut == true)
        {
            FadeScreen.GetComponent<Animation>().Play("FadeBtW");
            fadedOut = false;
        }
    }

    public void Fade2Black()
    {
        if (fadedOut == false)
        {
            FadeScreen.GetComponent<Animation>().Play("FadeWtB");
            fadedOut = true;
        }
    }
}
