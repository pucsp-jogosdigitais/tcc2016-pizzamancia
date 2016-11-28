using UnityEngine;
using System.Collections;

public class TiroBoss : MonoBehaviour
{
    #region atributos
    //animacao
	public Animator animadorTiroBoss;

    //Rigidbody e colisao
	public Rigidbody2D rdbTiroBoss;

    //atirador
	public Boss atirador; //boss que o atirou

    //mecanica
	public int dano; //dano causado pelo tiro
	public float forcaRecuo;
	Vector2 posicaoRelativaInicial; //posicao onde comeca em relacao ao atirador
	public float velocidade; //velocidade
	public float duracaoAtaque; //duracao na tela em segundos
	Vector2 posicaoAlvo; //posicao para onde foi mirado
	public float cooldown;
	public float tempoPassadoCooldown;
    #endregion

    void Awake()
    {
        animadorTiroBoss = this.GetComponent<Animator>();

		rdbTiroBoss = this.GetComponent<Rigidbody2D>();

		atirador = GameObject.Find ("Malvagius").GetComponent<Boss> ();

		posicaoAlvo = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void Start()
    {
        float sentido = posicaoRelativaInicial.x;
		Vector2 direcaoVirada = atirador.transform.localScale;

        if (direcaoVirada.x < 0)
        {
            sentido *= -1f;
        }

		transform.position = new Vector2 (atirador.transform.position.x + sentido,
			atirador.transform.position.y + posicaoRelativaInicial.y);

		disparar ();

        Destroy(gameObject, duracaoAtaque);
    }

    #region getters e setters
    public Animator AnimadorTiroBoss
    {
        get { return animadorTiroBoss; }
        set { animadorTiroBoss = value; }
    }

    public Rigidbody2D RdbTiroBoss
    {
        get { return rdbTiroBoss; }
        set { rdbTiroBoss = value; }
    }

    public Boss Atirador
    {
        get { return atirador; }
        set { atirador = value; }
    }

    public int Dano
    {
        get { return dano; }
        set { dano = value; }
    }

	public float ForcaRecuo
	{
		get { return forcaRecuo; }
		set { forcaRecuo = value; }
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
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), colisor);
        }
        else
        {
            switch (colisor.gameObject.tag.ToString())
            {
                default:
                    break;
                case "Inimigo":
                    Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), colisor);

                    return;
				case "EscudoBoss":
					Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), colisor);

					return;
                case "Hitbox":
                    Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), colisor);

                    return;
                case "Headbox":
                    Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), colisor);

                    return;
                case "Player":
                    Jogador jogador = colisor.gameObject.GetComponent<Jogador>();
					Vector2 direcaoTras = jogador.transform.right;

                    jogador.alterarVida(-dano);

					if (this.transform.position.x > jogador.transform.position.x)
					{
						jogador.RdbAtor.AddForce((Vector2.up - direcaoTras) * forcaRecuo, ForceMode2D.Impulse);
					}
					else if (this.transform.position.x < jogador.transform.position.x)
					{
						jogador.RdbAtor.AddForce((Vector2.up + direcaoTras) * forcaRecuo, ForceMode2D.Impulse);
					}

                    break;
                case "Obstaculo":
                    Obstaculo obstaculo = colisor.gameObject.GetComponent<Obstaculo>();

                    obstaculo.alterarVida(-dano);

                    break;
            }

            Destroy(gameObject);
        }
    }
    #endregion

    #region acoes
    public void disparar()
    {
		Vector2 posicaoOrigem = new Vector2 (this.transform.position.x, this.transform.position.y);
		Vector2 direcao = (posicaoAlvo - posicaoOrigem).normalized;

		rdbTiroBoss.AddForce(direcao * velocidade * 100);
    }
    #endregion
}
