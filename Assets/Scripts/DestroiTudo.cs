using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiTudo : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(morte());
    }

    
    IEnumerator morte()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
