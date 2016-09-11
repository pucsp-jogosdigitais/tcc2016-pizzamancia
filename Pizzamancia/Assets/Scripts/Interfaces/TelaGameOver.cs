using UnityEngine;
using System.Collections;

public class TelaGameOver : MonoBehaviour
{
    public GameObject telaGameOver; //GameObject que armazena a UI de menu de pause

    Jogador jogador;

    // Use this for initialization
    void Start()
    {
        telaGameOver.SetActive(false);

        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jogador.Chances < 0)
        {
            acabarJogo();
        }
    }

    public void acabarJogo()
    {
        jogador.IsControlavel = false;

        GameManager.getInstance().pararJogo();
        telaGameOver.SetActive(true);
    }

    public void reiniciarLevel()
    {
        telaGameOver.SetActive(false);

        GameManager.getInstance().continuarJogo();
        GameManager.getInstance().recarregarLevel();
    }

    public void retornarSelecLevel()
    {
        telaGameOver.SetActive(false);

        GameManager.getInstance().continuarJogo();
        GameManager.getInstance().carregarTela("MenuSelecLevel");
    }
}
