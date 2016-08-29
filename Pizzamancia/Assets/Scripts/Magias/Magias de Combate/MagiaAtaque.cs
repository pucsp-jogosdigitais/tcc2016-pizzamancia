using UnityEngine;
using System.Collections;

public class MagiaAtaque : MonoBehaviour {
	//animacao
	public Sprite spriteMagiaAtaque;
	public Animator animadorMagiaAtaque;

    //jogador
    public Jogador conjurador;

	//mecanica
	//dano causado por cada ataque
	public int dano;
	//posicao onde ataque comeca em relacao ao conjurador
	public Vector3 posicaoInicial;
	//direcao do ataque
	public Vector2 direcao;
	//velocidade de cada ataque
	public float velocidade;
	//duracao na tela em segundos de cada ataque
	public int duracaoAtaque;

	// Use this for initialization
	void Start () {		
		float sentido = posicaoInicial.x;
		direcao = conjurador.transform.right;

		if (direcao.x < 0) {
			sentido *= -1f;
		}

		transform.position = new Vector3 (
			conjurador.transform.position.x + sentido, 
			conjurador.transform.position.y + posicaoInicial.y, 
			conjurador.transform.position.z + posicaoInicial.z);

		Destroy (gameObject, duracaoAtaque);
	}
	
	// Update is called once per frame
	void Update () {
		mover ();
	}

    public Sprite SpriteMagiaAtaque 
	{
		get { return spriteMagiaAtaque; }
        set { spriteMagiaAtaque = value; }
	}

    public Animator AnimadorMagiaAtaque
    {
        get { return animadorMagiaAtaque; }
        set { animadorMagiaAtaque = value; }
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

	public Vector3 PosicaoInicial {
		get { return posicaoInicial; }
		set { posicaoInicial = value; }
	}

	public Vector2 Direcao {
		get { return direcao; }
		set { direcao = value; }
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

	public void mover () {
		transform.Translate (direcao * velocidade * Time.deltaTime);
	}

	public void OnCollisionEnter2D (Collision2D colisor) {
		switch (colisor.gameObject.tag.ToString ()) {
			case "AtaqueMagico":
				var ataqueMagico = colisor.gameObject.GetComponent<MagiaAtaque> ();

				Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), colisor.gameObject.GetComponent<Collider2D> ());

				return;
					break;
			case "Inimigo":
				var inimigo = colisor.gameObject.GetComponent<Inimigo> ();

				inimigo.alterarVida (-dano);

            	Destroy(gameObject);
					break;
			case "Obstaculo":
				var obstaculo = colisor.gameObject.GetComponent<Obstaculo> ();

				if (obstaculo.VidaTotal != 0) {
					obstaculo.alterarVida (-dano);
				}

            	Destroy(gameObject);
					break;
		} 

		Destroy(gameObject);
	}
}
