using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inimigo : Ator
{
	#region atributos
	//movimentacao em relacao ao jogador
	public float raioPercepcao;
	public bool isDetectou;
	Jogador jogador;
	public float distanciaInimigoJogador;
	//public Vector3 posicaoInicial;
	//public float distanciaPosicaoInicial;
	#endregion

    // Use this for initialization
    void Start()
	{
        this.Velocidade = 2;
        this.ForcaPulo = 4;

		this.VidaTotal = 10;
		this.VidaAtual = vidaTotal;

		jogador = GameObject.FindGameObjectWithTag ("Player").GetComponent<Jogador> ();

        raioPercepcao = 5;
    }

    // Update is called once per frame
    void Update()
    {
        vigiar();

		if (isDetectou) {
			perseguirJogador ();
		}
    }
		
	#region getters e setters
	public float RaioPercepcao
	{
		get { return raioPercepcao; }
		set { raioPercepcao = value; }
	}

	public bool IsDetectou
	{
		get { return isDetectou; }
		set { isDetectou = value; }
	}

	public float DistanciaInimigoJogador
	{
		get { return distanciaInimigoJogador; }
		set { distanciaInimigoJogador = value; }
	}
	#endregion

	//acoes automaticas
    public void vigiar ()
    {
		distanciaInimigoJogador = Vector2.Distance(jogador.transform.position, this.transform.position);

		if (distanciaInimigoJogador <= raioPercepcao)
        {
            isDetectou = true;
        }
        else
        {
            isDetectou = false;
        }
    }
		
    //acoes basicas
    public void perseguirJogador()
    {
		if ((jogador.transform.position.x - this.transform.position.x) < 0) {
			this.MovimentoX = -1;
		} else if ((jogador.transform.position.x - this.transform.position.x) > 0) {
			this.MovimentoX = 1;
		}
    }

	public void voltarPosicaoInicial () {
	}

	public void morrer()
	{
		Destroy (gameObject);
	}
}
