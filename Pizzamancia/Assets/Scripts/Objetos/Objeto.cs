using UnityEngine;
using System.Collections;

public class Objeto : MonoBehaviour
{
	#region atributos
	//animacao
	public Animator animadorObjeto;
	//funcionamento
	public float tempoVida;
	public float velocidade;
	#endregion

	// Use this for initialization
	void Start () {
		if (tempoVida > 0) {
			Destroy (gameObject, tempoVida);
		}
	}

	// Update is called once per frame
	void Update () {
	}
		
	#region getters e setters
	public Animator AnimadorObjeto
	{
		get { return animadorObjeto; } 
		set { animadorObjeto = value; }
	}

	public float TempoVida
	{
		get { return tempoVida; } 
		set { tempoVida = value; }
	}

	public float Velocidade
	{
		get { return velocidade; } 
		set { velocidade = value; }
	}
	#endregion
}
