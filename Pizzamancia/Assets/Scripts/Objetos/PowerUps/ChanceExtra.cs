using UnityEngine;
using System.Collections;

public class ChanceExtra : PowerUp {

	// Use this for initialization
	void Start () {
		this.TempoVida = 0;
		this.Velocidade = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter2D (Collision2D colisor) {
		if (colisor.gameObject.tag == "Player") {
			var player = colisor.gameObject.GetComponent<Jogador> ();

			player.Chances++;
		}

		Destroy (gameObject);
	}
}
