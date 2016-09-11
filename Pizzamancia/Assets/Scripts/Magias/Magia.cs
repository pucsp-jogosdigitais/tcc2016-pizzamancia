using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class Magia : MonoBehaviour {
	#region atributos
	//identificacao
	public string nome;
	public Image icone;

	//variaveis mecanicas
	public int custoMana;
	public float cooldown;
	public float tempoPassado;
	public float duracao;

	//preco
	public int preco;
	#endregion

	// Use this for initialization
	void Start () {
		tempoPassado = cooldown;
	}

	#region getters e setters
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
	#endregion

	#region metodo para conjurar
	public virtual void conjurar () {
	}
	#endregion
}
