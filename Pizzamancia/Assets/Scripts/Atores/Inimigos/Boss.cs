using UnityEngine;
using System.Collections;

public class Boss : Inimigo
{
    #region atributos
    //estados
    public int estadoAtual;
    const int IDLE = -1;
    const int PAUSA1 = 0;
    const int ATAQUE1 = 1;
    const int PAUSA2 = 2;
    const int ATAQUE2 = 3;
    const int LEVITARBAIXO = 4;
    const int PAUSABAIXO = 5;
    const int ATAQUEBAIXO = 6;
    const int SUPERVULNERAVEL = 8;
    const int PAUSAREPELIR = 9;
    const int REPELIR = 10;
    const int LEVITARALTO = 11;

    //duracao e tempo passado nos estados
    public float duracaoPausa;
    float tempoPassadoPausa;
    public float duracaoAtacando;
    float tempoPassadoAtacando;
    public float duracaoSuperVulneravel;
    float tempoPassadoSuperVulneravel;
    #endregion

    // Use this for initialization
    void Start()
    {
        base.Start();

        estadoAtual = IDLE;

        duracaoPausa = 1f;
        tempoPassadoPausa = 0;
        duracaoAtacando = 10f;
        tempoPassadoAtacando = 0;
        duracaoSuperVulneravel = 1.5f;
        tempoPassadoSuperVulneravel = 0;

        this.VelocidadeMaximaOriginal = 4f;
        this.VelocidadeMaxima = this.VelocidadeMaximaOriginal;

        this.HitboxAtor.DanoOriginal = 5;
        this.HitboxAtor.Dano = this.HitboxAtor.DanoOriginal;

        this.DemoraAntesAtaqueOriginal = 0.5f;
        this.DemoraAntesAtaque = this.DemoraAntesAtaqueOriginal;
        this.DemoraDepoisAtaqueOriginal = 0.5f;
        this.DemoraDepoisAtaque = this.DemoraDepoisAtaqueOriginal;
        this.AlcanceAtaque = 0.16f;

        this.VidaTotalOriginal = 100;
        this.VidaTotal = this.VidaTotalOriginal;
        this.VidaAtual = this.VidaTotalOriginal;
    }

    // Update is called once per frame
    void Update()
    {
        switch (estadoAtual)
        {
            default:

                break;
            case IDLE:

                break;
            case PAUSA1:
                if (tempoPassadoPausa <= duracaoAtacando)
                {
                    tempoPassadoPausa += Time.timeScale;
                }
                else
                {
                    tempoPassadoPausa = 0;
                    estadoAtual = ATAQUE1;
                }

                break;
            case ATAQUE1:
                if (tempoPassadoAtacando <= duracaoAtacando)
                {
                    tempoPassadoAtacando += Time.timeScale;
                }
                else
                {
                    tempoPassadoAtacando = 0;

                    if (this.vidaAtual <= (this.VidaTotalOriginal / 4))
                    {
                        estadoAtual = PAUSA2;
                    }
                    else
                    {
                        estadoAtual = LEVITARBAIXO;
                    }
                }

                break;
            case PAUSA2:
                if (tempoPassadoPausa <= duracaoAtacando)
                {
                    tempoPassadoPausa += Time.timeScale;
                }
                else
                {
                    tempoPassadoPausa = 0;
                    estadoAtual = ATAQUE2;
                }

                break;
            case ATAQUE2:
                if (tempoPassadoAtacando <= duracaoAtacando)
                {
                    tempoPassadoAtacando += Time.timeScale;
                }
                else
                {
                    tempoPassadoAtacando = 0;

                    estadoAtual = LEVITARBAIXO;
                }

                break;
            case LEVITARBAIXO:
                estadoAtual = PAUSABAIXO;

                break;
            case PAUSABAIXO:
                if (tempoPassadoPausa <= duracaoAtacando)
                {
                    tempoPassadoPausa += Time.timeScale;
                }
                else
                {
                    tempoPassadoPausa = 0;
                    estadoAtual = ATAQUEBAIXO;
                }

                break;
            case ATAQUEBAIXO:
                if (tempoPassadoAtacando <= duracaoAtacando)
                {
                    tempoPassadoAtacando += Time.timeScale;
                }
                else
                {
                    tempoPassadoAtacando = 0;

                    estadoAtual = SUPERVULNERAVEL;
                }

                break;
            case SUPERVULNERAVEL:
                if (tempoPassadoSuperVulneravel <= duracaoSuperVulneravel)
                {
                    tempoPassadoSuperVulneravel += Time.timeScale;
                }
                else
                {
                    tempoPassadoSuperVulneravel = 0;

                    estadoAtual = PAUSAREPELIR;
                }

                break;
            case PAUSAREPELIR:
                if (tempoPassadoPausa <= duracaoPausa)
                {
                    tempoPassadoPausa += Time.timeScale;
                }
                else
                {
                    tempoPassadoPausa = 0;

                    estadoAtual = REPELIR;
                }

                break;
            case REPELIR:
                estadoAtual = LEVITARALTO;

                break;
            case LEVITARALTO:
                estadoAtual = PAUSA1;

                break;
        }

        //if (isPausado)
        //{
        //    if (tempoPassadoPausa <= duracaoPausa)
        //    {
        //        tempoPassadoPausa += Time.timeScale;
        //    }
        //    else
        //    {
        //        tempoPassadoPausa = 0;

        //        isPausado = false;
        //    }
        //}
        //else if (isAtacando)
        //{
        //    if (tempoPassadoLoop <= duracaoAtacando)
        //    {
        //    }
        //}
    }

    #region acoes
    public void comecarLuta()
    {
        estadoAtual = PAUSA1;
    }

    public void atacar()
    {
    }

    public void levitar()
    {
    }
    #endregion
}
