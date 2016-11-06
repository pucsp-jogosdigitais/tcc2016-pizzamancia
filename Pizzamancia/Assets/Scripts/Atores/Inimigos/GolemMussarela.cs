using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GolemMussarela : Inimigo
{
    // Use this for initialization
    void Start()
    {
        base.Start();

        this.AlcanceCentroVagar = 5f;

        this.RaioPercepcao = 8f;

        this.VelocidadeMaximaOriginal = 1f;
        this.VelocidadeMaxima = this.VelocidadeMaximaOriginal;
        this.ForcaPuloOriginal = 2f;
        this.ForcaPulo = this.ForcaPuloOriginal;

        this.HitboxAtor.DanoOriginal = 5;
        this.HitboxAtor.Dano = this.HitboxAtor.DanoOriginal;
        this.HitboxAtor.ForcaRecuoOriginal = 5f;
        this.HitboxAtor.ForcaRecuo = this.HitboxAtor.ForcaRecuoOriginal;

        this.DemoraAntesAtaqueOriginal = 1f;
        this.DemoraAntesAtaque = this.DemoraAntesAtaqueOriginal;
        this.DemoraDepoisAtaqueOriginal = 1f;
        this.DemoraDepoisAtaque = this.DemoraDepoisAtaqueOriginal;
        this.AlcanceAtaque = 0.9f;

        this.VidaTotalOriginal = 20;
        this.VidaTotal = this.VidaTotalOriginal;
        this.VidaAtual = this.VidaTotalOriginal;

        this.Pontos = 10;
    }
}
