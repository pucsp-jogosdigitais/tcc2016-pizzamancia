using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MorcegoCalabresa : Inimigo
{
	// Use this for initialization
	void Start()
	{
		this.RaioPercepcao = 2.5f;
		this.Alvo = GameObject.FindGameObjectWithTag ("Player").GetComponent<Jogador> ();

		this.Velocidade = 2;
		this.ForcaPulo = 4;

		this.HitboxAtor.Dano = 5;
		this.DemoraAntesAtaque = 0.5f;
		this.DemoraDepoisAtaque = 0.5f;
		this.AlcanceAtaque = 0.16f;

		this.VidaTotal = 5;
		this.VidaAtual = vidaTotal;

		this.Pontos = 3;
	}
}
