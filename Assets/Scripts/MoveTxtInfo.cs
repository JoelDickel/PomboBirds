using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTxtInfo : MonoBehaviour
{
    private Vector3 pos;
    private RectTransform rt;
    private bool libera = false;
    private GameObject btnBlock, nomeJogo;


    //para o texto andar infinitamente
    private RectTransform uiRect1, uiRect2;

    private void Awake()
    {
        uiRect1 = (RectTransform) GameObject.FindWithTag("CanvasBack").GetComponent<RectTransform>();
        uiRect2 = (RectTransform) GameObject.FindWithTag("infoTxt").GetComponent<RectTransform>();

        btnBlock = GameObject.FindWithTag("btnBlock");
        btnBlock.SetActive(false);
        nomeJogo = GameObject.FindWithTag("NomeJogo");
        rt = GetComponent<RectTransform>();
        pos = rt.anchoredPosition;
    }

    void Update()
    {
        if(libera)
        {
            transform.Translate(0, 1 * Time.deltaTime, 0);
        }
        else
        {
            rt.anchoredPosition = pos;
        }

        if (!RectOverLap(uiRect1, uiRect2))
        {
            rt.anchoredPosition = pos;
        }


    }

    public void LiberaMov()
    {
        nomeJogo.SetActive(false);
        btnBlock.SetActive(true);
        libera = true;
        ControlBtnMenu.instance.chave2 = false;
        ControlBtnMenu.instance.btnAnimatorConfig.Play("InverseConfiBtnAnima");
    }

    public void BlockMov()
    {
        nomeJogo.SetActive(true);
        libera = false;
        btnBlock.SetActive(false);
    }

    bool RectOverLap(RectTransform rectTrans1, RectTransform rectTrans2)
    {
        Rect rect1 = new Rect(rectTrans1.localPosition.x, rectTrans1.localPosition.y, rectTrans1.rect.width, rectTrans1.rect.height);
        Rect rect2 = new Rect(rectTrans2.localPosition.x, rectTrans2.localPosition.y, rectTrans2.rect.width, rectTrans2.rect.height);

        return rect1.Overlaps(rect2);
    }

}
