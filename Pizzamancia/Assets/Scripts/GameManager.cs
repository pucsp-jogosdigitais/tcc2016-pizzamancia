using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    #region atributos
    //instancia
    public static GameManager gameManagerInst;

    //pontuacao
    public int pontosLevel;
    public int pontosGlobal;

    //condicao para encerramento de fase
    public bool isLevelCompleto;
    #endregion

    // Use this for initialization
    void Start()
    {
        gameManagerInst = this;

        pontosLevel = 0;
        pontosGlobal = pontosLevel;

        isLevelCompleto = false;
    }

    #region getters e setters
    public static GameManager getInstance()
    {
        return gameManagerInst;
    }

    public int PontosLevel
    {
        get { return pontosLevel; }
        set { pontosLevel = value; }
    }

    public int PontosGlobal
    {
        get { return pontosGlobal; }
        set { pontosGlobal = value; }
    }

    public bool IsLevelCompleto
    {
        get { return isLevelCompleto; }
        set { isLevelCompleto = value; }
    }
    #endregion

    #region navegacao geral
    //carrega interfaces e levels
    public void carregarTela(string tela)
    {
        Fade.fade.ChangeScene(tela);
    }

    public void carregarTelaSemFade(string tela)
    {
        Application.LoadLevel(tela);
    }

    //recarrega level atual
    public void recarregarLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //sai do jogo
    public void sairJogo()
    {
        Application.Quit();
    }
    #endregion

    #region parada e continuacao do jogo
    public void pararJogo()
    { //para o jogo
        Time.timeScale = 0;
    }

    public void continuarJogo()
    { //continua o jogo
        Time.timeScale = 1;
    }
    #endregion

    #region inicio, salva e carregamento de jogo
    //inicia novo jogo
    public void iniciarNovoJogo()
    {
    }

    //salva o jogo
    public void salvarJogo()
    {
    }

    //carrega jogo salvo
    public void carregarJogoSalvo()
    {
    }
    #endregion

    #region configuracoes
    //configuracoes de jogo
    //configuracoes de video
    //configuracoes de audio
    #endregion

    #region comeco e finalizacao de level
    //preparacao e inicio de level

    //encerramento de level
    #endregion

    #region alteracao de status
    //aumenta ou diminui os pontos obtidos no level
    public void alterarPontos(int valor)
    {
        int resultadoFinal = pontosLevel + valor;

        if (resultadoFinal < 0)
        {
            pontosLevel = 0;
        }
        else
        {
            pontosLevel += valor;
        }
    }
    #endregion
}
