using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TelaLevelCompleto : MonoBehaviour
{
    #region atributos
    Jogador jogador;

    public GameObject telaLevelCompleto; //GameObject que armazena a UI de menu de pause
    Text pontosObtidosLevel;
    Text pontosObtidosGlobal;
    #endregion

    // Use this for initialization
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();

        pontosObtidosLevel = GameObject.Find("Pontos Obtidos Level").GetComponent<Text>();
        pontosObtidosGlobal = GameObject.Find("Pontos Obtidos Global").GetComponent<Text>();

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

        GameManager.getInstance().PontosGlobal += GameManager.getInstance().PontosLevel;

        pontosObtidosLevel.text = "Pontos obtidos na fase: " + GameManager.getInstance().PontosLevel.ToString("0000");
        pontosObtidosLevel.text = "Pontos totais obtidos: " + GameManager.getInstance().PontosGlobal.ToString("0000");

        GameManager.getInstance().pararJogo();
        telaLevelCompleto.SetActive(true);
    }

    public void reiniciarLevel()
    {
        telaLevelCompleto.SetActive(false);

        GameManager.getInstance().continuarJogo();
        GameManager.getInstance().recarregarLevel();
    }

    public void retornarSelecLevel()
    {
        telaLevelCompleto.SetActive(false);

        GameManager.getInstance().continuarJogo();
        GameManager.getInstance().carregarTelaSemFade("MenuSelecLevel");
    }

    public void retornarMenuPrincipal()
    {
        telaLevelCompleto.SetActive(false);

        GameManager.getInstance().continuarJogo();
        GameManager.getInstance().carregarTelaSemFade("MenuPrincipal");
    }
    #endregion
}
