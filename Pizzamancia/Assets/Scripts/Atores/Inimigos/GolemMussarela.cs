using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GolemMussarela : Inimigo
{
    void Start()
    {
        base.Start();

        this.RaioPercepcao = 8f;

        this.VelocidadeMaximaOriginal = 1.5f;
        this.VelocidadeMaxima = this.VelocidadeMaximaOriginal;

        this.HitboxAtor.DanoOriginal = 10;
        this.HitboxAtor.Dano = this.HitboxAtor.DanoOriginal;
        this.HitboxAtor.ForcaRecuoOriginal = 5f;
        this.HitboxAtor.ForcaRecuo = this.HitboxAtor.ForcaRecuoOriginal;

        this.DemoraAntesAtaqueOriginal = 1f;
        this.DemoraAntesAtaque = this.DemoraAntesAtaqueOriginal;
        this.DemoraDepoisAtaqueOriginal = 1f;
        this.DemoraDepoisAtaque = this.DemoraDepoisAtaqueOriginal;
        this.AlcanceAtaque = 1.8f;

        this.VidaTotalOriginal = 30;
        this.VidaTotal = this.VidaTotalOriginal;
        this.VidaAtual = this.VidaTotalOriginal;

        this.DuracaoAtordoamento = 0.3f;

        this.Pontos = 20;

        this.TempoMorte = 0.8f;
    }
}
