using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class Magia : MonoBehaviour {
	//identificacao
	public string nome;
	public Image icone;

	//animacao
	public Animator animadorMagia;

	//jogador
	private Jogador conjurador;

	//variaveis mecanicas
	public int custoMana;
	public float cooldown;
	public float tempoPassado;
	public float duracao;

	//preco
	public int preco;

	// Use this for initialization
	void Start () {
		tempoPassado = cooldown;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public string Nome
	{
		get { return nome; } 
		set { nome = value; }
	}

	public Image Icone 
	{
		get { return icone; }
		set { icone = value; }
	}

	public Animator AnimadorMagia
	{
		get { return animadorMagia; } 
		set { animadorMagia = value; }
	}

	public Jogador Conjurador {
		get { return conjurador; }
		set { conjurador = value; }
	}

	public int CustoMana
	{
		get { return custoMana; } 
		set { custoMana = value; }
	}

	public float Cooldown
	{
		get { return cooldown; } 
		set { cooldown = value; }
	}

	public float TempoPassado
	{
		get { return tempoPassado; } 
		set { tempoPassado = value; }
	}

	public float Duracao
	{
		get { return duracao; } 
		set { duracao = value; }
	}
		
	public int Preco
	{
		get { return preco; } 
		set { preco = value; }
	}

	public virtual void conjurar () {
	}
}
