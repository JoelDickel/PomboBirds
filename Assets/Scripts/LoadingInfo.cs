using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingInfo : MonoBehaviour
{
    public TextMeshProUGUI txtCarregando;

    public void BtnClick()
    {
        StartCoroutine(LoadGameProg());
    }

   
    //Estrutura para Fazer uma scena de Loading
    IEnumerator LoadGameProg()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(2);

        while (!async.isDone)
        {
            txtCarregando.enabled = true;
            yield return null;
        }

    }

}
