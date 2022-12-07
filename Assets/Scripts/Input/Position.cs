﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Position : MonoBehaviour
{
    public Text txt;
    Touch toque;

    
    void Update()
    {
        if(Input.touchCount > 0)
        {
            toque = Input.GetTouch(0);
            
            if(toque.phase == TouchPhase.Began)
            {
                if(toque.position.x > (Screen.width / 2))
                {
                    txt.text = "Direita";
                }
                else
                {
                    txt.text = "Esquerda";
                }
            }
        }
    }
}
