using UnityEngine;
using System.Collections;

public class Boss : Inimigo
{
    #region atributos
    public int ataqueAtual;
    public float demoraAtancado;
    public float tempoAtacando;
    #endregion

    // Use this for initialization
    void Start()
    {
        base.Start();

        this.VelocidadeMaximaOriginal = 4f;
        this.VelocidadeMaxima = this.VelocidadeMaximaOriginal;

        demoraAtancado = 5f;
        tempoAtacando = 0;

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
        if (tempoAtacando <= demoraAtancado)
        {
            tempoAtacando += Time.deltaTime;

            lancarAtaque();
        }
        else
        {
            tempoAtacando = 0;
            ataqueAtual++;

            if ((ataqueAtual == 3 && (this.VidaAtual > (this.VidaTotalOriginal / 2))) ||
                (ataqueAtual == 4 && (this.VidaAtual > (this.VidaTotalOriginal / 4))) ||
                (ataqueAtual == 5))
            {
                //ataqueAtual = 1;
            }
        }
    }

    #region acoes
    public void levitar()
    {
    }

    public void lancarAtaque()
    {
    }
    #endregion
}
