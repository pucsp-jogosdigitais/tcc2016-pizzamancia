using UnityEngine;
using System.Collections;

public class AtaqueMagico : MonoBehaviour {
	#region atributos
	//animacao
	public Animator animadorMagiaAtaque;

	//Rigidbody e colisao
	public Rigidbody2D rdbMagiaAtaque;

    //jogador
    public Jogador conjurador;

	//mecanica
	public int dano; //dano causado por cada ataque
	public Vector3 posicaoRelativaInicial; //posicao onde ataque comeca em relacao ao conjurador
	float sentido;
	Vector3 direcao; //direcao do ataque
	public float velocidade; //velocidade de cada ataque
	public int duracaoAtaque; //duracao na tela em segundos de cada ataque
	#endregion

	void Awake(){
		animadorMagiaAtaque = this.GetComponent<Animator> ();

		rdbMagiaAtaque = this.GetComponent<Rigidbody2D> ();

		conjurador = GameObject.FindGameObjectWithTag ("Player").GetComponent<Jogador> ();
	}

	// Use this for initialization
	void Start () {		
		sentido = posicaoRelativaInicial.x;
		direcao = conjurador.transform.right;

		if (direcao.x < 0) {
			sentido *= -1f;
		}

		transform.position = new Vector3 (
			conjurador.transform.position.x + sentido, 
			conjurador.transform.position.y + posicaoRelativaInicial.y, 
			conjurador.transform.position.z + posicaoRelativaInicial.z);

		Destroy (gameObject, duracaoAtaque);
	}
	
	// Update is called once per frame
	void Update () {
		mover ();
	}
		
	#region getters e setters
    public Animator AnimadorMagiaAtaque
    {
        get { return animadorMagiaAtaque; }
        set { animadorMagiaAtaque = value; }
    }

	public Rigidbody2D RdbMagiaAtaque
	{
		get { return rdbMagiaAtaque; }
		set { rdbMagiaAtaque = value; }
	}

    public Jogador Conjurador
    {
        get { return conjurador; }
        set { conjurador = value; }
    }

	public int Dano 
	{
		get { return dano; }
		set { dano = value; }
	}

	public Vector3 PosicaoRelativaInicial {
		get { return posicaoRelativaInicial; }
		set { posicaoRelativaInicial = value; }
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

	#region eventos
	public void OnCollisionEnter2D (Collision2D colisor) {
		switch (colisor.gameObject.tag.ToString ()) {
		default:
			break;
		case "AtaqueMagico":
			var ataqueMagico = colisor.gameObject.GetComponent<AtaqueMagico> ();

			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), colisor.gameObject.GetComponent<Collider2D> ());

			return;
			break;
		case "Inimigo":
			var inimigo = colisor.gameObject.GetComponent<Inimigo> ();

			inimigo.alterarVida (-dano);
			break;
		case "Obstaculo":
			var obstaculo = colisor.gameObject.GetComponent<Obstaculo> ();

			if (obstaculo.VidaTotal != 0) {
				obstaculo.alterarVida (-dano);
			}
			break;
		case "PowerUp":
			var powerUp = colisor.gameObject.GetComponent<PowerUp> ();

			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), colisor.gameObject.GetComponent<Collider2D> ());

			return;
			break;
		}

		Destroy(gameObject);
	}
	#endregion

	#region acoes
	public void mover () {
		rdbMagiaAtaque.velocity = new Vector2(direcao.x * velocidade, rdbMagiaAtaque.velocity.y);
	}
	#endregion
}
