﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplos : MonoBehaviour
{
    private Vector3 start;
    public Rigidbody2D pass1, pass2, passaroRb, passPrefab;
    private bool libera = false;
    public int trava = 0;
    private Touch touch;
    private TrailRenderer rastro;


    void Start()
    {
        passaroRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            {
                if (touch.phase == TouchPhase.Ended && trava < 2 && passaroRb.isKinematic == false)
                {
                    trava++;
                    if (trava == 2)
                    {
                        start = transform.position;
                        pass1 = Instantiate(passPrefab, new Vector3(start.x, start.y + 0.1f, start.z),Quaternion.identity);
                        pass2 = Instantiate(passPrefab, new Vector3(start.x, start.y - 0.1f, start.z), Quaternion.identity);
                        libera = true;
                    }


                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (libera){
            pass1.velocity = passaroRb.velocity * 1.6f;
            passaroRb.velocity = passaroRb.velocity * 1.4f;
            pass2.velocity = passaroRb.velocity * 1.1f;
            libera = false;
        }
    }
}
