using UnityEngine;
using System.Collections;

public class Chave : Objeto {
	#region atributos
	public Porta portaRespectiva;
	#endregion

	// Use this for initialization
	void Start () {
		this.TempoVida = 0;
		this.Velocidade = 0;
	}

	#region getters e setters
	public Porta PortaRespectiva
	{
		get{ return portaRespectiva; }
		set{ portaRespectiva = value; }
	}
	#endregion

	#region evento
	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			portaRespectiva.abrir ();

			Destroy(gameObject);
		}	
	}
	#endregion
}
