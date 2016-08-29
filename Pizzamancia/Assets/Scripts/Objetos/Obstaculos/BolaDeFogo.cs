using UnityEngine;
using System.Collections;

public class BolaDeFogo : Obstaculo {
	public Vector2 direcao;

	// Use this for initialization
	void Start () {
		this.TempoVida = 2000;
		this.Velocidade = 1;
		this.VidaTotal = 0;
	}

	// Update is called once per frame
	void Update () {
		mover ();
	}

	public Vector2 Direcao {
		get{ return direcao; }
		set { direcao = value; }
	}

	public void mover() {
		transform.Translate (Vector2.left * this.Velocidade * Time.deltaTime);
	}

	public void OnCollisionEnter2D (Collision2D colisor) {
		if (colisor.gameObject.tag == "Player") {
			var player = colisor.gameObject.GetComponent<Jogador> ();
      
			player.alterarVida (-10);
		}

        Destroy(gameObject);
	}
}
