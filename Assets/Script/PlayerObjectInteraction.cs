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
    public int punkProgress;
    public int jamProgress;
    public int dndProgress;
    //public int prepProgress = 0;
    public bool hasEnergy;
    public bool hasKeys;
    public bool gaveupToday;

    public int giveUpProgress;

    [SerializeField]
    GameObject[] punkItems;
    [SerializeField]
    GameObject[] jamItems;
    [SerializeField]
    GameObject[] dndItems;

    [SerializeField]
    GameObject[] energyItems;

    [SerializeField]
    GameObject[] junkItems;

    [SerializeField]
    GameObject keys;


    // Start is called before the first frame update

    void Start()
    {
        punkProgress = 0;
        jamProgress = 0;
        dndProgress = 0;
        giveUpProgress = 0;

        startDay();

        ItemSpawning();
    }
    

    public void IncrementItem(string ItemClass)
    {
       switch (ItemClass)
       {
            case "punk":
                punkProgress++;
                print("got punk item"); break;
            case "jam":
                jamProgress++;      break;
            case "dnd":
                dndProgress++;      break;
            case "energy":
                hasEnergy = true;      break;
            case "keys":
                hasKeys = true;
                print("got keys");  break;
       }
    }
    private void startDay()
    {
        //prepProgress = 0;
        hasEnergy = false;
        hasKeys = false;
    }

    //🗲
    public void ItemSpawning()
    {
        /*
         *Something like each item type has a progression except for junk and that progression is
         * put into an array and the progression number is what's called from the array. Winning or 
         * losing resets the progression numbers.
         * 
         * The energy item is a daily check
         * 
         * The keys are a must to leave the door, and maybe have three spawn locations
         */
        //punk item
        punkItems[punkProgress].SetActive(true);
        //dnd item
        dndItems[dndProgress].SetActive(true);
        //jam item
        jamItems[jamProgress].SetActive(true);
        //energy item
        energyItems[Random.Range(0, 3)].SetActive(true);

        for (int i = 0; i < 4; i++)
        {
            junkItems[i].SetActive(true);
        }
        //keys
        keys.SetActive(true);
        gaveupToday = false;
    }

    public void ItemDespawn()
    {
        //punk item
        punkItems[Mathf.Clamp(punkProgress, 0, 2)].SetActive(false);
        //dnd item
        dndItems[Mathf.Clamp(dndProgress, 0,2)].SetActive(false);
        //jam item
        jamItems[Mathf.Clamp(jamProgress, 0, 2)].SetActive(false);
        //energy item
        for (int i = 0; i < 3; i++)
        {
            energyItems[i].SetActive(false);
        }

        for (int i = 0; i < 4; i++)
        {
            junkItems[i].SetActive(false);
        }
        //keys
        keys.SetActive(false);
    }

    //GETTERS
    public int GetPunkProg()
    {
        return punkProgress;
    }
    public int GetDNDProg()
    {
        return dndProgress;
    }
    public int GetJamProg()
    {
        return jamProgress;
    }
    public int GetGiveUpProg()
    {
        return giveUpProgress;
    }

    //SETTERS

    public void AddGiveUp()
    {
        if (gaveupToday == false)
        {
            giveUpProgress++;
            gaveupToday = true;
        }
    }
}
