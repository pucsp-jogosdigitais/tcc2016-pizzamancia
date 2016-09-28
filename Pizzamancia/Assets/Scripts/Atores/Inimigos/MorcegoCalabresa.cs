﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MorcegoCalabresa : Inimigo
{
    // Use this for initialization
    void Start()
    {
        base.Start();

        this.AlcanceCentroVagar = 5f;

        this.RaioPercepcao = 2.5f;

        this.VelocidadeOriginal = 2;
        this.Velocidade = this.VelocidadeOriginal;
        this.ForcaPuloOriginal = 4;
        this.ForcaPulo = this.ForcaPuloOriginal;

        this.HitboxAtor.DanoOriginal = 5;
        this.HitboxAtor.Dano = this.HitboxAtor.DanoOriginal;

        this.DemoraAntesAtaqueOriginal = 0.5f;
        this.DemoraAntesAtaque = this.DemoraAntesAtaqueOriginal;
        this.DemoraDepoisAtaqueOriginal = 0.5f;
        this.DemoraDepoisAtaque = this.DemoraDepoisAtaqueOriginal;
        this.AlcanceAtaque = 0.16f;

        this.VidaTotalOriginal = 5;
        this.VidaTotal = this.VidaTotalOriginal;
        this.VidaAtual = this.VidaTotalOriginal;

        this.Pontos = 3;
    }
}
