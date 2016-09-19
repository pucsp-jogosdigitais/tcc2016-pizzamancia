using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GolemMussarela : Inimigo
{
	// Use this for initialization
	void Start()
	{
		this.RaioPercepcao = 8f;
		this.Alvo = GameObject.FindGameObjectWithTag ("Player").GetComponent<Jogador> ();

		this.Velocidade = 1;
		this.ForcaPulo = 2;

		this.HitboxAtor.Dano = 10;
		this.DemoraAntesAtaque = 1f;
		this.DemoraDepoisAtaque = 1f;
		this.AlcanceAtaque = 0.6f;

		this.VidaTotal = 20;
        this.VidaAtual = this.VidaTotal;

		this.Pontos = 10;
	}
}
