using UnityEngine;
using System.Collections;

public class Alteracao : MonoBehaviour {
	public Ator alvo;
	public float duracao;  //quanto tempo a alteracao fica ativo

	// Use this for initialization
	void Start () {
		Destroy (gameObject, duracao);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public float Duracao {
		get { return duracao; }
		set { duracao = value; }
	}
}
