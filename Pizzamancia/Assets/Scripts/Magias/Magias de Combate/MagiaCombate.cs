using UnityEngine;
using System.Collections;

public class MagiaCombate : Magia {
	#region atributos
	//public GameObject ataqueMagico;
	public int numeroAtaques; //numero de ataques (projeteis) lancados
	public int dano; //dano causado por cada ataque
	public float velocidade; //velocidade de cada ataque
	public int duracaoAtaque; //duracao na tela em segundos de cada ataque
	#endregion

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region getters e setters
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
	#endregion
}
