using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    #region atributos
    //instancia
    public static GameManager gameManagerInst;

    public bool isCursorHabilitado;

    //pontuacao
    public int pontosLevel;

    float timescale = 0;

    //condicao para encerramento de fase
    public bool isLevelCompleto;
    #endregion

    // Use this for initialization
    void Start()
    {
        timescale = Time.timeScale;
        gameManagerInst = this;

        if (isCursorHabilitado)
        {
            habilitarCursor();
        }
        else
        {
            desabilitarCursor();
        }

        pontosLevel = 0;

        isLevelCompleto = false;

        continuarJogo();
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

    public bool IsLevelCompleto
    {
        get { return isLevelCompleto; }
        set { isLevelCompleto = value; }
    }
    #endregion

    #region navegacao geral
    public void habilitarCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void desabilitarCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

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
    //para o jogo
    public void pararJogo()
    {
        Time.timeScale = 0;
    }

    //continua o jogo
    public void continuarJogo()
    {
        Time.timeScale = 1f;
    }
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
