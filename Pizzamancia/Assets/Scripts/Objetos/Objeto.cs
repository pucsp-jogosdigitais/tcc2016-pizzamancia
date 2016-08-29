using UnityEngine;
using System.Collections;

public class Objeto : MonoBehaviour
{
	//animacao
	public Sprite spriteObjeto;
	public Animator animadorObjeto;
	//funcionamento
	public float tempoVida;
	public float velocidade;

	// Use this for initialization
	void Start () {
		if (tempoVida > 0) {
			Destroy (gameObject, tempoVida);
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public Sprite SpriteObjeto
	{
		get { return spriteObjeto; } 
		set { spriteObjeto = value; }
	}

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
}
