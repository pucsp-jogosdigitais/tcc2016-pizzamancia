using UnityEngine;
using System.Collections;

public class Ponto : Objeto {
	#region atributos
	public int valor;
	#endregion

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	#region getters e setters
	public int Valor {
		get { return valor; }
		set { valor = value; }
	}
	#endregion

	#region eventos
	public void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Player")
		{
			GameManager.getInstance ().alterarPontos (valor);

			Destroy (gameObject);
		}
	}
	#endregion
}
