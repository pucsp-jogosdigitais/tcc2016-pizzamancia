using UnityEngine;
using System.Collections;

public class RajadaDeAzeitonas : MagiaCombate {
	public GameObject ataqueMagico;

	// Use this for initialization
	void Start () {
		this.Nome = "Rajada de Azeitonas";
		//this.Icone;

		//this.SpriteMagia;
		//this.AnimadorMagia;

		this.CustoMana = 5;
		this.Cooldown = 1;
		this.TempoPassado = this.Cooldown;
		this.Duracao = 0;

		this.NumeroAtaques = 5;
		this.Dano = 1;
		this.Velocidade = 4;
		this.DuracaoAtaque = 5;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void conjurar () {
		ataqueMagico.GetComponent<MagiaAtaque> ().Conjurador = this.Conjurador;
		ataqueMagico.GetComponent <MagiaAtaque> ().Dano = this.Dano;
		//
		ataqueMagico.GetComponent <MagiaAtaque> ().Velocidade = this.Velocidade;
		ataqueMagico.GetComponent <MagiaAtaque> ().DuracaoAtaque = this.DuracaoAtaque;

		for (int qtdAtq = 0; qtdAtq < this.NumeroAtaques; qtdAtq++) {
			float distanciaAtaque = qtdAtq * 0.1f;

			ataqueMagico.GetComponent <MagiaAtaque> ().PosicaoInicial = new Vector3 (0.3f + distanciaAtaque, 0f, 0f);

			Instantiate (ataqueMagico, ataqueMagico.transform.position, new Quaternion());
		}
	}
}
