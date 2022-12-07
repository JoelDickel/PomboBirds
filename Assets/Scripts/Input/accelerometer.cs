using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerometer : MonoBehaviour
{
    

    void Update()
    {
        transform.Translate(Input.acceleration.x, Input.acceleration.y, 0);
    }
}
