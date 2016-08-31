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

	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			var player = collider.gameObject.GetComponent<Jogador>();

			player.alterarChances(1);

			Destroy(gameObject);
		}
	}
}
