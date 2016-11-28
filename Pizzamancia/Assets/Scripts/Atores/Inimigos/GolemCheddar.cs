using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GolemCheddar : Inimigo
{
    void Start()
    {
        base.Start();

        this.RaioPercepcao = 8f;

        this.VelocidadeMaximaOriginal = 0.5f;
        this.VelocidadeMaxima = this.VelocidadeMaximaOriginal;

        this.HitboxAtor.DanoOriginal = 20;
        this.HitboxAtor.Dano = this.HitboxAtor.DanoOriginal;
        this.HitboxAtor.ForcaRecuoOriginal = 7f;
        this.HitboxAtor.ForcaRecuo = this.HitboxAtor.ForcaRecuoOriginal;

        this.DemoraAntesAtaqueOriginal = 1.5f;
        this.DemoraAntesAtaque = this.DemoraAntesAtaqueOriginal;
        this.DemoraDepoisAtaqueOriginal = 1.5f;
        this.DemoraDepoisAtaque = this.DemoraDepoisAtaqueOriginal;
        this.AlcanceAtaque = 1.8f;

        this.VidaTotalOriginal = 40;
        this.VidaTotal = this.VidaTotalOriginal;
        this.VidaAtual = this.VidaTotalOriginal;

        this.DuracaoAtordoamento = 0.15f;

        this.Pontos = 40;

        this.TempoMorte = 0.8f;
    }
}
