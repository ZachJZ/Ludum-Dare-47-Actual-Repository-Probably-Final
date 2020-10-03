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
    public int punkProgress=0;
    public int dndProgress =0;
    public int gamejamProgress =0;
    public int prepProgress = 0;
    public int energy = 0;
    public bool hasKeys;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    

    public void IncrementItem(string ItemClass)
    {
       switch (ItemClass) 
       {
            case "punk":
                punkProgress++;     break;
            case "dnd":
                dndProgress++;      break;
            case "gamejam":
                gamejamProgress++;  break;
            case "energy":
                energy++;           break;
            case "prep":
                prepProgress++;     break;
            case "keys":
                hasKeys = true;     break;
       }
    }
    private void startDay()
    {
        prepProgress = 0;
        energy = 0;
        hasKeys = false;
    }
}
