using UnityEngine;
using System.Collections;

public class AtaqueMagico : MonoBehaviour
{
    #region atributos
    //animacao
    public Animator animadorMagiaAtaque;

    //Rigidbody e colisao
    public Rigidbody2D rdbMagiaAtaque;

    //jogador
    Jogador conjurador;

    //mecanica
    public int dano; //dano causado por cada ataque
    public Vector2 posicaoRelativaInicial; //posicao onde ataque comeca em relacao ao conjurador
	Vector2 direcaoVirada; //direcao do ataque
    public float velocidade; //velocidade de cada ataque
    public int duracaoAtaque; //duracao na tela em segundos de cada ataque
    #endregion

    void Awake()
    {
		
        animadorMagiaAtaque = this.GetComponent<Animator>();

        rdbMagiaAtaque = this.GetComponent<Rigidbody2D>();

        conjurador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
    }

    // Use this for initialization
    void Start()
	{
        float sentido = posicaoRelativaInicial.x;
		direcaoVirada = conjurador.transform.localScale;

        if (direcaoVirada.x < 0)
        {
            sentido *= -1f;
        }

        transform.position = new Vector3(conjurador.transform.position.x + sentido,
            conjurador.transform.position.y + posicaoRelativaInicial.y);

        Destroy(gameObject, duracaoAtaque);
    }

    // Update is called once per frame
    void Update()
    {
        mover();
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

    public Vector3 PosicaoRelativaInicial
    {
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
			case "Player":
				Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), colisor);

				return;
			case "AtaqueMagico":
				Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), colisor);

				return;
			case "Hitbox":
				Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), colisor);

				return;
			case "Headbox":
				Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), colisor);

				return;
			case "Inimigo":
				Inimigo inimigo = colisor.gameObject.GetComponent<Inimigo> ();

				inimigo.alterarVida (-dano);

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
        rdbMagiaAtaque.velocity = new Vector2(direcaoVirada.x * velocidade, rdbMagiaAtaque.velocity.y);
    }
    #endregion
}
