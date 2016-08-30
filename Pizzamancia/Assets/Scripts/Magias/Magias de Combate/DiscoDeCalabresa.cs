using UnityEngine;
using System.Collections;

public class DiscoDeCalabresa : MagiaCombate {
	#region atributos
	public GameObject ataqueMagico;
	#endregion

	// Use this for initialization
	void Start () {
		this.Nome = "Disco de Calabresa";
		//this.Icone;

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
		ataqueMagico.GetComponent <AtaqueMagico> ().Dano = this.Dano;
		ataqueMagico.GetComponent <AtaqueMagico> ().PosicaoRelativaInicial = new Vector3 (0.3f, 0f, 0f);
		ataqueMagico.GetComponent <AtaqueMagico> ().Velocidade = this.Velocidade;
		ataqueMagico.GetComponent <AtaqueMagico> ().DuracaoAtaque = this.DuracaoAtaque;
    
        Instantiate (ataqueMagico, ataqueMagico.transform.position, new Quaternion());
	}
}
