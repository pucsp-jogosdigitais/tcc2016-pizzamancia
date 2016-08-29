using UnityEngine;
using System.Collections;

public class MagiaCombate : Magia {
	public int numeroAtaques;
	//dano causado por cada ataque
	public int dano;
	//velocidade de cada ataque
	public float velocidade;
	//duracao na tela em segundos de cada ataque
	public int duracaoAtaque;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int NumeroAtaques
	{
		get { return numeroAtaques; }
		set { numeroAtaques = value; }
	}

	public int Dano 
	{
		get { return dano; }
		set { dano = value; }
	}

	public float Velocidade 
	{
		get { return velocidade; }
		set { velocidade = value; }
	}

	public int DuracaoAtaque
	{
		get { return duracaoAtaque; }
		set { duracaoAtaque = value; }
	}
}
