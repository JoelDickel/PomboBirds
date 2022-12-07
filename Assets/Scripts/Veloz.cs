using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veloz : MonoBehaviour
{

    public Rigidbody2D passaroRb;
    public bool libera = false;
    public int trava = 0;
    private Touch touch;

    void Start()
    {
        passaroRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //com o mouse e tbm funciona no celular
        /*if(Input.GetMouseButtonDown(0)&& passaroRb.isKinematic == false && trava == 0)
        {
            libera = true;
            trava = 1;
        }*/
        //apenas com o touch
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            {
                if(touch.phase == TouchPhase.Ended && trava < 2 && passaroRb.isKinematic == false)
                {
                    trava++;
                    if(trava == 2)
                    {
                        libera = true;
                    }
                   
                    
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (libera)
        {
            passaroRb.velocity = passaroRb.velocity * 2.5f;
            libera = false;
        }
    }
}
