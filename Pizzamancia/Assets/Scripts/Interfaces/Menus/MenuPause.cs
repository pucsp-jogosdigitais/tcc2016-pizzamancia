using UnityEngine;
using System.Collections;

public class MenuPause : MonoBehaviour
{
    public GameObject menuDePause; //GameObject que armazena a UI de menu de pause
    public GameObject painelReiniciarLevel;
    public GameObject painelSelecLevel;
    public GameObject painelSairJogo;

    bool isPaused; //informa se o jogo está pausado ou nao

    Jogador jogador;

    // Use this for initialization
    void Start()
    {
        menuDePause.SetActive(false);
        painelReiniciarLevel.SetActive(false);
        painelSelecLevel.SetActive(false);
        painelSairJogo.SetActive(false);
        isPaused = false;
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!isPaused)
            {
                pausarJogo();
            }
            else
            {
                if (painelReiniciarLevel.activeInHierarchy)
                {
                    painelReiniciarLevel.SetActive(false);
                }
                else if (painelSelecLevel.activeInHierarchy)
                {
                    painelSelecLevel.SetActive(false);
                }
                else if (painelSairJogo.activeInHierarchy)
                {
                    painelSairJogo.SetActive(false);
                }
                else
                {
                    retomarJogo();
                }
            }
        }
    }

    //pausa o jogo
    public void pausarJogo()
    {
        isPaused = true;
        jogador.IsControlavel = false;

        GameManager.getInstance().pararJogo();
        menuDePause.SetActive(true);
    }

    //retoma o jogo pausado
    public void retomarJogo()
    {
        isPaused = false;
        jogador.IsControlavel = true;

        menuDePause.SetActive(false);
        painelReiniciarLevel.SetActive(false);
        painelSelecLevel.SetActive(false);
        painelSairJogo.SetActive(false);

        GameManager.getInstance().continuarJogo();
    }

    public void reiniciarLevel()
    {
        isPaused = false;

        GameManager.getInstance().continuarJogo();
        GameManager.getInstance().recarregarLevel();
    }

    public void retornarSelecLevel()
    {
        isPaused = false;

        GameManager.getInstance().continuarJogo();
        GameManager.getInstance().carregarTela("MenuSelecLevel");
    }
}
