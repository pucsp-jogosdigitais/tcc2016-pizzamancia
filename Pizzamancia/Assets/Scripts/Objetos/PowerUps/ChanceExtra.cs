using UnityEngine;
using System.Collections;

public class ChanceExtra : PowerUp {
	public AudioSource source;
	// Use this for initialization
	void Start () {
		source = GameObject.Find("Audio ambiente").GetComponent<AudioSource>();
		this.TempoVida = 0;
		this.Velocidade = 0;
	}

	#region evento
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			Jogador jogador = collider.gameObject.GetComponent<Jogador>();

			jogador.alterarChances(1);
			source.PlayOneShot(this.SomPego, 5f);
			Destroy(gameObject);
		}
	}
	#endregion
}
