using UnityEngine;
using System.Collections;

public class DiscoDeCalabresa : MagiaCombate {
	public GameObject ataqueMagico;

	// Use this for initialization
	void Start () {
		this.Nome = "Disco de Calabresa";
		//this.Icone;

		//this.SpriteMagia;
		//this.AnimadorMagia;

		this.CustoMana = 10;
		this.Cooldown = 5;
		this.TempoPassado = this.Cooldown;
		this.Duracao = 0;

        this.Preco = 0;

		this.NumeroAtaques = 1;
		this.Dano = 10;
		this.Velocidade = 2;
		this.DuracaoAtaque = 5;
	}

	// Update is called once per frame
	void Update () {

	}

	public override void conjurar () {
		ataqueMagico.GetComponent<MagiaAtaque> ().Conjurador = this.Conjurador;
		ataqueMagico.GetComponent <MagiaAtaque> ().Dano = this.Dano;
		ataqueMagico.GetComponent <MagiaAtaque> ().PosicaoInicial = new Vector3 (0.3f, 0f, 0f);
		ataqueMagico.GetComponent <MagiaAtaque> ().Velocidade = this.Velocidade;
		ataqueMagico.GetComponent <MagiaAtaque> ().DuracaoAtaque = this.DuracaoAtaque;
    
        Instantiate (ataqueMagico, ataqueMagico.transform.position, new Quaternion());
	}
}
