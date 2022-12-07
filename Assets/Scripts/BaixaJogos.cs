using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaixaJogos : MonoBehaviour
{
   public void BtnBaixaJogos()
    {
        Application.OpenURL("market://details?id=com.wtncursos.MaxGoal");
    }
}
