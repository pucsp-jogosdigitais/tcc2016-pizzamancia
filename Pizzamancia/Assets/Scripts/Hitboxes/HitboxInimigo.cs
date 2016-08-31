using UnityEngine;
using System.Collections;

public class HitboxInimigo : Hitbox {
	// Use this for initialization
	void Start () {	
	}

	// Update is called once per frame
	void Update () {
	}

	#region eventos
	public void OnTriggerEnter2D (Collider2D colisor) {
		switch (colisor.gameObject.tag.ToString ()) {
		default:
			break;
		case "Player":
			var jogador = colisor.gameObject.GetComponent<Jogador> ();

			jogador.alterarVida (-Dano);
			break;
		case "Obstaculo":
			var obstaculo = colisor.gameObject.GetComponent<Obstaculo> ();

			if (obstaculo.VidaTotal != 0) {
				obstaculo.alterarVida (-Dano);
			}
			break;
		}
	}
	#endregion
}
