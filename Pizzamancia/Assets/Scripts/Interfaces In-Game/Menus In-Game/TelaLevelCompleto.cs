using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TelaLevelCompleto : MonoBehaviour
{
    #region atributos
    Jogador jogador;

    public GameObject telaLevelCompleto; //GameObject que armazena a UI de menu de pause
    public Text pontosObtidosLevel;
    public Text pontosObtidosGlobal;
    #endregion

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();

        telaLevelCompleto.SetActive(false);
    }

    void Update()
    {
        if (GameManager.getInstance().IsLevelCompleto)
        {
            completarLevel();
        }
    }

    #region getters e setters
    public Text PontosObtidosLevel
    {
        get { return pontosObtidosLevel; }
        set { pontosObtidosLevel = value; }
    }

    public Text PontosObtidosGlobal
    {
        get { return pontosObtidosLevel; }
        set { pontosObtidosLevel = value; }
    }
    #endregion

    #region funcoes
    public void completarLevel()
    {
        jogador.IsControlavel = false;

        GameManager.getInstance().habilitarCursor();

        pontosObtidosLevel.text = "Pontos obtidos na fase: " + GameManager.getInstance().PontosLevel.ToString("0000");

        GameManager.getInstance().pararJogo();
        telaLevelCompleto.SetActive(true);
    }

    public void continuar(string tela)
    {
        telaLevelCompleto.SetActive(false);

        GameManager.getInstance().continuarJogo();
        GameManager.getInstance().carregarTela(tela);
    }

    public void retornarMenuPrincipal()
    {
        telaLevelCompleto.SetActive(false);

        GameManager.getInstance().continuarJogo();
        GameManager.getInstance().carregarTelaSemFade("MenuPrincipal");
    }
    #endregion
}
