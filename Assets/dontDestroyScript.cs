using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
