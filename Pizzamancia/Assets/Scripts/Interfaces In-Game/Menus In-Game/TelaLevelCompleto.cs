using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TelaLevelCompleto : MonoBehaviour
{
    #region atributos
    public GameObject telaLevelCompleto; //GameObject que armazena a UI de menu de pause
    GameObject pontosObtidos;

    Jogador jogador;
    #endregion

    // Use this for initialization
    void Start()
    {
        telaLevelCompleto.SetActive(false);

        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
    }

    #region getters e setters
    public GameObject PontosObtidos
    {
        get { return pontosObtidos; }
        set { pontosObtidos = value; }
    }
    #endregion

    #region funcoes
    public void completarLevel()
    {
        jogador.IsControlavel = false;
        //pontosObtidos.GetComponent<Text> ().text = GameManager.getInstance ().PontosLevel.ToString("0000");

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
    #endregion
}
