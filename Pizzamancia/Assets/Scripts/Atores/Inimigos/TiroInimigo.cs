using UnityEngine;
using System.Collections;

public class TiroInimigo : MonoBehaviour 
{
	#region atributos
	//animacao
	public Animator animadorTiroInimigo;

	//Rigidbody e colisao
	public Rigidbody2D rdbTiroInimigo;

	//atirador
	public Inimigo atirador; //inimigo que o atirou

	//mecanica
	public int dano; //dano causado pelo tiro
	public Vector2 posicaoRelativaInicial; //posicao onde comeca em relacao ao atirador
	Vector2 direcaoVirada; //direcao
	public float velocidade; //velocidade
	public float duracaoAtaque; //duracao na tela em segundos
	public Vector2 posicaoAlvo; //posicao para onde foi mirado
	public float cooldown;
	public float tempoPassadoCooldown;
	#endregion

	void Awake()
	{
		animadorTiroInimigo = this.GetComponent<Animator>();

		rdbTiroInimigo = this.GetComponent<Rigidbody2D>();

		posicaoAlvo = GameObject.FindGameObjectWithTag ("Player").transform.position;
		tempoPassadoCooldown = 0;
	}

	// Use this for initialization
	void Start()
	{
		float sentido = posicaoRelativaInicial.x;
		direcaoVirada = atirador.transform.localScale;

		if (direcaoVirada.x < 0)
		{
			sentido *= -1f;
		}

		transform.position = new Vector3(atirador.transform.position.x + sentido,
			atirador.transform.position.y + posicaoRelativaInicial.y);

		Destroy(gameObject, duracaoAtaque);
	}

	// Update is called once per frame
	void Update()
	{
		mover();
	}

	#region getters e setters
	public Animator AnimadorTiroInimigo
	{
		get { return animadorTiroInimigo; }
		set { animadorTiroInimigo = value; }
	}

	public Rigidbody2D RdbTiroInimigo
	{
		get { return rdbTiroInimigo; }
		set { rdbTiroInimigo = value; }
	}

	public Inimigo Atirador
	{
		get { return atirador; }
		set { atirador = value; }
	}

	public int Dano
	{
		get { return dano; }
		set { dano = value; }
	}

	public Vector2 PosicaoRelativaInicial
	{
		get { return posicaoRelativaInicial; }
		set { posicaoRelativaInicial = value; }
	}

	public float Velocidade
	{
		get { return velocidade; }
		set { velocidade = value; }
	}

	public float DuracaoAtaque
	{
		get { return duracaoAtaque; }
		set { duracaoAtaque = value; }
	}

	public Vector2 PosicaoAlvo
	{
		get { return posicaoAlvo; }
		set { posicaoAlvo = value; }
	}

	public float Cooldown
	{
		get { return cooldown; }
		set { cooldown = value; }
	}

	public float TempoPassadoCooldown
	{
		get { return tempoPassadoCooldown; }
		set { tempoPassadoCooldown = value; }
	}
	#endregion

	#region eventos
	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.layer == 9) 
		{
			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), colisor);
		} 
		else 
		{
			switch (colisor.gameObject.tag.ToString ()) 
			{
			default:
				break;
			case "Inimigo":
				Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), colisor);

				return;
			case "Hitbox":
				Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), colisor);

				return;
			case "Headbox":
				Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), colisor);

				return;
			case "Player":
				Jogador jogador = colisor.gameObject.GetComponent<Jogador> ();

				jogador.alterarVida (-dano);

				break;	
			case "Obstaculo":
				Obstaculo obstaculo = colisor.gameObject.GetComponent<Obstaculo> ();

				obstaculo.alterarVida (-dano);

				break;
			}

			Destroy(gameObject);
		}
	}
	#endregion

	#region acoes
	public void mover()
	{
		this.transform.position = Vector2.MoveTowards (this.transform.position, posicaoAlvo, (velocidade / 25));
	}
	#endregion
}
