using UnityEngine;
using System.Collections;

public class Obstaculo : Objeto {
	//vida
	public int vidaTotal;
	public int vidaAtual;

	// Use this for initialization
	void Start () {
		if (vidaTotal > 0) {
			vidaAtual = vidaTotal;
		}
	}
		
	// Update is called once per frame
	void Update () {
	}

	public int VidaTotal
	{
		get { return vidaTotal; }
		set { vidaTotal = value; }
	}

	public int VidaAtual
	{
		get { return vidaAtual; }
		set { vidaAtual = value; }
	}

	//alteracoes de status
	public void alterarVida(int valor) {
		if (vidaTotal > 0) {
			int resultadoFinal = vidaAtual + valor;

			if (resultadoFinal > vidaTotal) {
				vidaAtual = vidaTotal;
			} else if (resultadoFinal <= 0) {
				vidaAtual = 0;
				Destroy (gameObject);
			} else {
				vidaAtual += valor;
			}
		}
	}
}
