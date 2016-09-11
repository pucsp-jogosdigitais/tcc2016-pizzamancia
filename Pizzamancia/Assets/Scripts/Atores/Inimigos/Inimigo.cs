using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inimigo : Ator
{
	#region atributos
	//movimentacao em relacao ao jogador
	public float raioPercepcao;
	public bool isDetectou;
	Jogador alvo;
	public float distanciaInimigoJogador;
	public float alcanceAtaque;

	//public Vector3 posicaoInicial;
	//public float distanciaPosicaoInicial;

	//pontos
	public int pontos;
	#endregion

    // Use this for initialization
    void Start()
	{
		raioPercepcao = 5;
		alvo = GameObject.FindGameObjectWithTag ("Player").GetComponent<Jogador> ();

        this.Velocidade = 2;
        this.ForcaPulo = 4;

		this.HitboxAtor.Dano = 5;
		this.DemoraAntesAtaque = 1f;
		this.DemoraDepoisAtaque = 0.5f;
		this.alcanceAtaque = 0.2f;

		this.VidaTotal = 10;
		this.VidaAtual = vidaTotal;

		pontos = 3;
    }

    // Update is called once per frame
    void Update()
    {
		distanciaInimigoJogador = Vector2.Distance(alvo.transform.position, this.transform.position);

        vigiar();

		if (isDetectou) {
			perseguirJogador ();

			if (distanciaInimigoJogador < alcanceAtaque) {
				this.comecarAtaque (true);
			}
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

	public Jogador Alvo 
	{
		get { return alvo; }
		set { alvo = value; }
	}

	public float DistanciaInimigoJogador
	{
		get { return distanciaInimigoJogador; }
		set { distanciaInimigoJogador = value; }
	}

	public float AlcanceAtaque
	{
		get { return alcanceAtaque; }
		set { alcanceAtaque = value; }
	}

	public int Pontos
	{
		get { return pontos; }
		set { pontos = value; }
	}
	#endregion

	//acoes automaticas
    public void vigiar ()
    {
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
		if ((alvo.transform.position.x - this.transform.position.x) < 0) {
			this.MovimentoX = -1;
		} else if ((alvo.transform.position.x - this.transform.position.x) > 0) {
			this.MovimentoX = 1;
		}
    }

	public void voltarPosicaoInicial () {
	}

	public override void morrer()
	{
		GameManager.getInstance ().alterarPontos (pontos);
		Destroy (gameObject);
	}
}
