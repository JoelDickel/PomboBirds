using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelManagerPB : MonoBehaviour
{

    public static LevelManagerPB instace;

    [System.Serializable]
    public class Level
    {
        public string levelText;
        public bool habilitado;
        public int desbloqueado;
        public bool txtAtivo;

    }

    public GameObject botao;
    public Transform localBtn;
    public List<Level> levelList;

    private void Awake()
    {

        ZPlayerPrefs.Initialize("123456", "pombobravo");

        if (instace == null)
        {
            instace = this;
        }
    }
    private void Start()
    {
        ZPlayerPrefs.SetInt("level1", 1);
      

        ListaAdd();
    }

    void ListaAdd()
    {
        foreach (Level level in levelList)
        {
            GameObject btnNovo = Instantiate(botao) as GameObject;
            botaoLevel btnNew = btnNovo.GetComponent<botaoLevel>();
            btnNew.levelTxtBTN.text = level.levelText;



            if (ZPlayerPrefs.GetInt("level" + btnNew.levelTxtBTN.text) == 1)
            {
                level.desbloqueado = 1;
                level.habilitado = true;
                level.txtAtivo = true;

            }

            btnNew.desbloqueadoBTN = level.desbloqueado;
            btnNew.GetComponent<Button>().interactable = level.habilitado;
            btnNew.GetComponentInChildren<Text>().enabled = level.txtAtivo;
            btnNew.GetComponent<Button>().onClick.AddListener(() => ClickLevel("level" + btnNew.levelTxtBTN.text));


            btnNew.estrela1.enabled = false;
            btnNew.estrela2.enabled = false;
            btnNew.estrela3.enabled = false;


            btnNovo.transform.SetParent(localBtn, false);
        }
    }

    void ClickLevel(string level)
    {

        SceneManager.LoadScene(level);
    }







}
















