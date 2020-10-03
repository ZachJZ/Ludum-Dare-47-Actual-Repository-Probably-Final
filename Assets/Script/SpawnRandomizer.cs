using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnRandomizer : MonoBehaviour
{
     public GameObject dndItem;
     public GameObject punkItem;
     public GameObject gamejamItem;
     public GameObject energyItem;
    public GameObject prepItem;
     public GameObject keys;
     public Transform spawn1;
     public Transform spawn2; 
     public Transform spawn3;  
     public Transform spawn4; 
     public Transform spawn5;
     public Transform spawn6;
     public Transform spawn7;
     public Transform spawn8;
     public Transform spawn9;
     public Transform spawn10;

    int [] position = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    List<int> positionlist = null;
    int[] itemType = new int[] { 1, 2, 3, 4, 5, 6 };
    List<int> itemTypeList = null;
    int i=0;
    // Start is called before the first frame update
    void Start()
    {
        dndItem = GameObject.Find("dndItem");
        punkItem = GameObject.Find("punkItem");
        gamejamItem = GameObject.Find("gamejamItem");
        prepItem = GameObject.Find("prepItem");
        energyItem = GameObject.Find("energyItem");
        keys = GameObject.Find("keys");
        spawn1 = GameObject.Find("spawn1").transform;
        spawn2 = GameObject.Find("spawn2").transform;
        spawn3 = GameObject.Find("spawn3").transform;
        spawn4 = GameObject.Find("spawn4").transform;
        spawn5 = GameObject.Find("spawn5").transform;
        spawn6 = GameObject.Find("spawn6").transform;
        spawn7 = GameObject.Find("spawn7").transform;
        spawn8 = GameObject.Find("spawn8").transform;
        spawn9 = GameObject.Find("spawn9").transform;
        spawn10 = GameObject.Find("spawn10").transform;

        Debug.Log(positionlist);
        positionlist.AddRange(position);
        Debug.Log(positionlist);
        for (i = 0; i < 10; i++)
        {
            Debug.Log("for loop ran");
            int spawnLocation = getRandomPos();
            int whichItem = getItemType();
            Debug.Log(spawnLocation);
            Debug.Log(whichItem);
            switch (spawnLocation)
            {
                case 1:
                    switch (whichItem)
                    {
                        case 1:
                            Instantiate(dndItem, spawn1.position, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(punkItem, spawn1.position, Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(gamejamItem, spawn1.position, Quaternion.identity);
                            break;
                        case 4:
                            Instantiate(prepItem, spawn1.position, Quaternion.identity);
                            break;
                        case 5:
                            Instantiate(energyItem, spawn1.position, Quaternion.identity);
                            break;
                        case 6:
                            Instantiate(keys, spawn1.position, Quaternion.identity);
                            break;
                    }
                    break;
                case 2:
                    switch (whichItem)
                    {
                        case 1:
                            Instantiate(dndItem, spawn2.position, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(punkItem, spawn2.position, Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(gamejamItem, spawn2.position, Quaternion.identity);
                            break;
                        case 4:
                            Instantiate(prepItem, spawn2.position, Quaternion.identity);
                            break;
                        case 5:
                            Instantiate(energyItem, spawn2.position, Quaternion.identity);
                            break;
                        case 6:
                            Instantiate(keys, spawn2.position, Quaternion.identity);
                            break;
                    }
                    break;
                case 3:
                    switch (whichItem)
                    {
                        case 1:
                            Instantiate(dndItem, spawn3.position, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(punkItem, spawn3.position, Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(gamejamItem, spawn3.position, Quaternion.identity);
                            break;
                        case 4:
                            Instantiate(prepItem, spawn3.position, Quaternion.identity);
                            break;
                        case 5:
                            Instantiate(energyItem, spawn3.position, Quaternion.identity);
                            break;
                        case 6:
                            Instantiate(keys, spawn3.position, Quaternion.identity);
                            break;
                    }
                    break;
                case 4:
                    switch (whichItem)
                    {
                        case 1:
                            Instantiate(dndItem, spawn4.position, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(punkItem, spawn4.position, Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(gamejamItem, spawn4.position, Quaternion.identity);
                            break;
                        case 4:
                            Instantiate(prepItem, spawn4.position, Quaternion.identity);
                            break;
                        case 5:
                            Instantiate(energyItem, spawn4.position, Quaternion.identity);
                            break;
                        case 6:
                            Instantiate(keys, spawn4.position, Quaternion.identity);
                            break;
                    }
                    break;
                case 5:
                    switch (whichItem)
                    {
                        case 1:
                            Instantiate(dndItem, spawn5.position, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(punkItem, spawn5.position, Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(gamejamItem, spawn5.position, Quaternion.identity);
                            break;
                        case 4:
                            Instantiate(prepItem, spawn5.position, Quaternion.identity);
                            break;
                        case 5:
                            Instantiate(energyItem, spawn5.position, Quaternion.identity);
                            break;
                        case 6:
                            Instantiate(keys, spawn5.position, Quaternion.identity);
                            break;
                    }
                    break;
                case 6:
                    switch (whichItem)
                    {
                        case 1:
                            Instantiate(dndItem, spawn6.position, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(punkItem, spawn6.position, Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(gamejamItem, spawn6.position, Quaternion.identity);
                            break;
                        case 4:
                            Instantiate(prepItem, spawn6.position, Quaternion.identity);
                            break;
                        case 5:
                            Instantiate(energyItem, spawn6.position, Quaternion.identity);
                            break;
                        case 6:
                            Instantiate(keys, spawn6.position, Quaternion.identity);
                            break;
                    }
                    break;
                case 7:
                    switch (whichItem)
                    {
                        case 1:
                            Instantiate(dndItem, spawn7.position, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(punkItem, spawn7.position, Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(gamejamItem, spawn7.position, Quaternion.identity);
                            break;
                        case 4:
                            Instantiate(prepItem, spawn7.position, Quaternion.identity);
                            break;
                        case 5:
                            Instantiate(energyItem, spawn7.position, Quaternion.identity);
                            break;
                        case 6:
                            Instantiate(keys, spawn7.position, Quaternion.identity);
                            break;
                    }
                    break;
                case 8:
                    switch (whichItem)
                    {
                        case 1:
                            Instantiate(dndItem, spawn8.position, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(punkItem, spawn8.position, Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(gamejamItem, spawn8.position, Quaternion.identity);
                            break;
                        case 4:
                            Instantiate(prepItem, spawn8.position, Quaternion.identity);
                            break;
                        case 5:
                            Instantiate(energyItem, spawn8.position, Quaternion.identity);
                            break;
                        case 6:
                            Instantiate(keys, spawn8.position, Quaternion.identity);
                            break;
                    }
                    break;
                case 9:
                    switch (whichItem)
                    {
                        case 1:
                            Instantiate(dndItem, spawn9.position, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(punkItem, spawn9.position, Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(gamejamItem, spawn9.position, Quaternion.identity);
                            break;
                        case 4:
                            Instantiate(prepItem, spawn9.position, Quaternion.identity);
                            break;
                        case 5:
                            Instantiate(energyItem, spawn9.position, Quaternion.identity);
                            break;
                        case 6:
                            Instantiate(keys, spawn9.position, Quaternion.identity);
                            break;
                    }
                    break;
                case 10:
                    switch (whichItem)
                    {
                        case 1:
                            Instantiate(dndItem, spawn10.position, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(punkItem, spawn10.position, Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(gamejamItem, spawn10.position, Quaternion.identity);
                            break;
                        case 4:
                            Instantiate(prepItem, spawn10.position, Quaternion.identity);
                            break;
                        case 5:
                            Instantiate(energyItem, spawn10.position, Quaternion.identity);
                            break;
                        case 6:
                            Instantiate(keys, spawn10.position, Quaternion.identity);
                            break;
                    }
                    break;
            }
        }
    }
    int getRandomPos()
    {
        if (positionlist.Count == 0)
        {
            //something to reload if needed
        }
        int rand = Random.Range(1, positionlist.Count);
        int value = positionlist[rand];
        positionlist.RemoveAt(rand);
        return value;
    }
    int getItemType()
    {
        int rand = Random.Range(1, itemTypeList.Count);
        int value = itemTypeList[rand];
        itemTypeList.RemoveAt(rand);
        return value;
    }
}
