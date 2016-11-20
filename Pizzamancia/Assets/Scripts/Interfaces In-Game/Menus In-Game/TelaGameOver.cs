using UnityEngine;
using System.Collections;

public class TelaGameOver : MonoBehaviour
{
    #region atributos
    Jogador jogador;
    public GameObject telaGameOver; //GameObject que armazena a UI de menu de pause 

    //audio
    public AudioSource audioSourceTela;
    public AudioClip clip;
    #endregion

    // Use this for initialization
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();

        telaGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (jogador.Chances < 0)
        {
            acabarJogo();
        }
    }

    #region funcoes
    public void acabarJogo()
    {
        jogador.IsControlavel = false;

        GameManager.getInstance().habilitarCursor();
        GameManager.getInstance().pararJogo();
        telaGameOver.SetActive(true);
        audioSourceTela.PlayOneShot(clip, 1f); // música de game over
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
        GameManager.getInstance().carregarTelaSemFade("MenuPrincipal");
    }

    public void retornarMenuPrincipal()
    {
        telaGameOver.SetActive(false);

        GameManager.getInstance().continuarJogo();
        GameManager.getInstance().carregarTelaSemFade("MenuPrincipal");
    }
    #endregion
}
