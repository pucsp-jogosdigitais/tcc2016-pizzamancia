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

        this.VelocidadeOriginal = 1;
        this.Velocidade = this.VelocidadeOriginal;
        this.ForcaPuloOriginal = 2;
        this.ForcaPulo = this.ForcaPuloOriginal;

        this.HitboxAtor.DanoOriginal = 5;
        this.HitboxAtor.Dano = this.HitboxAtor.DanoOriginal;

        this.DemoraAntesAtaqueOriginal = 1f;
        this.DemoraAntesAtaque = this.DemoraAntesAtaqueOriginal;
        this.DemoraDepoisAtaqueOriginal = 1f;
        this.DemoraDepoisAtaque = this.DemoraDepoisAtaqueOriginal;
        this.AlcanceAtaque = 0.6f;

        this.VidaTotalOriginal = 20;
        this.VidaTotal = this.VidaTotalOriginal;
        this.VidaAtual = this.VidaTotalOriginal;

        this.Pontos = 10;
    }
}
