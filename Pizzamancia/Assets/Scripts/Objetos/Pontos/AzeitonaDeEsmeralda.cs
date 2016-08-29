using UnityEngine;
using System.Collections;

public class AzeitonaDeEsmeralda : Objeto {
	public int valor;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int Valor {
		get { return valor; }
		set { valor = value; }
	}

	public void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			var player = collider.gameObject.GetComponent<Jogador> ();

			player.alterarPontos (valor);

            Destroy (gameObject);
		}
	}
}
