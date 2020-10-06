using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioSet : MonoBehaviour
{
    float myVol;

    AudioSource myAMP;

    // Start is called before the first frame update
    void Start()
    {
        if (myVol == 0)
        {
            myVol = 0.5f;
        }
        myAMP = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myAMP.volume != myVol)
        {
            myAMP.volume = myVol;
        }
    }

    public void SetVol(float seTo)
    {
        myVol = Mathf.Clamp(seTo, 0, 1);
    }

}
