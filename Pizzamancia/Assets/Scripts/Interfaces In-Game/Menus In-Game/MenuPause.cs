using UnityEngine;
using System.Collections;

public class MenuPause : MonoBehaviour
{
    #region atributos
    Jogador jogador;

    bool isPaused; //informa se o jogo está pausado ou nao

    public GameObject menuDePause; //GameObject que armazena a UI de menu de pause
    public GameObject painelReiniciarLevel;
    public GameObject painelSairJogo;
    #endregion

    // Use this for initialization
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();

        isPaused = false;

        menuDePause.SetActive(false);
        painelReiniciarLevel.SetActive(false);
        painelSairJogo.SetActive(false);
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

    #region funcoes
    //pausa o jogo
    public void pausarJogo()
    {
        isPaused = true;
        jogador.IsControlavel = false;

		GameManager.getInstance ().habilitarCursor ();
        GameManager.getInstance().pararJogo();
        menuDePause.SetActive(true);

    }

    //retoma o jogo pausado
    public void retomarJogo()
    {
        isPaused = false;
        jogador.IsControlavel = true;

		GameManager.getInstance ().desabilitarCursor ();
        GameManager.getInstance().continuarJogo();
		menuDePause.SetActive(false);
		painelReiniciarLevel.SetActive(false);
		painelSairJogo.SetActive(false);
    }

    public void reiniciarLevel()
    {
        isPaused = false;

        GameManager.getInstance().continuarJogo();
        GameManager.getInstance().recarregarLevel();
    }

    public void retornarMenuPrincipal()
    {
        isPaused = false;

        GameManager.getInstance().continuarJogo();
        GameManager.getInstance().carregarTelaSemFade("MenuPrincipal");
    }
    #endregion
}
