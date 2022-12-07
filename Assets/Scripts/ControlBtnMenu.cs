using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBtnMenu : MonoBehaviour
{

    public static ControlBtnMenu instance;

    //btn mais jogos
    public Animator btnAnimator;
    private bool chave = true;

    //btn config
    public Animator btnAnimatorConfig;
    public bool chave2 = true;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void EventoClickG()
    {
        chave = !chave;

        if (chave == false)
        {
            btnAnimator.Play("MaisGames");
        }
        if (chave == true)
        {
            btnAnimator.Play("MaisGamesInverse");
        }
    }

    public void EventoClickConfig()
    {
        chave2 = !chave2;

        if (chave2 == false)
        {
            btnAnimatorConfig.Play("ConfiBtnAnima");
        }
        if (chave2 == true)
        {
            btnAnimatorConfig.Play("InverseConfiBtnAnima");
        }
    }
}
