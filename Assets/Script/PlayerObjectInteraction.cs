using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Transactions;
using UnityEngine;
using UnityEngine.AI;

public class PlayerObjectInteraction : MonoBehaviour
{
    public int punkProgress=1;
    public int dndProgress=1;
    public int gamejamProgress=1;
    public int prepProgress = 1;
    public int energy = 1;
    public bool hasKeys;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider col) //each item will have a collider in the space you would move to pick it up
    {
        var centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperCenter;
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Press F to pick up", centeredStyle);
        if (Input.GetKey(KeyCode.F))
        {
            if (col.gameObject.tag == "punkItem")
            {
                punkProgress += 1;
            }
            if (col.gameObject.tag == "dndItem")
            {
                dndProgress += 1;
            }
            if (col.gameObject.tag == "gamejamItem")
            {
                gamejamProgress += 1;
            }
            if (col.gameObject.tag == "prepItem")
            {
                prepProgress += 1;
            }
            if (col.gameObject.tag == "energyItem")
            {
                energy += 1;
            }
            if (col.gameObject.tag == "keys")
            {
                hasKeys = true;
            }

            Destroy(col.gameObject); //if player gets destroyed instead of item, this is the reason
                //play pick up sound, maybe add 
        }
    }
}
