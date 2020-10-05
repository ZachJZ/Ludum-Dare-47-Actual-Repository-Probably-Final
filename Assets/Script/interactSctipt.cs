using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class interactSctipt : MonoBehaviour
{
    [SerializeField]
    GameObject interactText;

    //GameObject myText;

    // Start is called before the first frame update
    void Start()
    {
        //myText = interactText.GetComponent<Text>();
        SetText(false);
    }

    public void SetText(bool setTo)
    {
        interactText.SetActive(setTo);
    }
}
