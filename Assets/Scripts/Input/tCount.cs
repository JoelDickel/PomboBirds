﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class tCount : MonoBehaviour
{
    public Text txt;
    public int toques;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            toques += Input.touchCount;
            txt.text = toques.ToString();
        }
    }
}
