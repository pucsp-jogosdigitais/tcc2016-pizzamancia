using UnityEngine;
using System.Collections;

public class HitboxJogador : Hitbox {
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
		case "Inimigo":
			var inimigo = colisor.gameObject.GetComponent<Inimigo> ();

			inimigo.alterarVida (-Dano);
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
