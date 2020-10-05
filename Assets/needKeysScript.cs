using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needKeysScript : MonoBehaviour
{
    [SerializeField]
    GameObject interactText;

    // Update is called once per frame
    void Start()
    {
        SetKeysText(false);

    }

    public void SetKeysText(bool setTo)
    {
        print("SetTo for Keys is " + setTo);
        interactText.SetActive(setTo);
    }

}
