using UnityEngine;
using System.Collections;

public class Boss : Inimigo
{
    #region atributos
    //estados
    public int estadoAtual;
    const int IDLE = -1;
    const int PAUSA1 = 0;
    const int ATAQUE1 = 1;
    const int PAUSA2 = 2;
    const int ATAQUE2 = 3;
    const int LEVITARBAIXO = 4;
    const int PAUSABAIXO = 5;
    const int ATAQUEBAIXO = 6;
    const int SUPERVULNERAVEL = 7;
    const int PAUSAREPELIR = 8;
    const int REPELIR = 9;
    const int LEVITARALTO = 10;

    //duracao e tempo passado nos estados
    public float duracaoPausa;
	public float tempoPassadoPausa;
    public float duracaoAtacando;
	public float tempoPassadoAtacando;
    public float duracaoSuperVulneravel;
	public float tempoPassadoSuperVulneravel;

	//ataques
	public TiroInimigo ataque1;
	public TiroInimigo ataque2;
	public TiroInimigo ataque3;
    #endregion

    // Use this for initialization
    void Start()
    {
        base.Start();

        estadoAtual = IDLE;

        duracaoPausa = 2f;
        tempoPassadoPausa = 0;
        duracaoAtacando = 10f;
        tempoPassadoAtacando = 0;
        duracaoSuperVulneravel = 4f;
        tempoPassadoSuperVulneravel = 0;

        this.VelocidadeMaximaOriginal = 4f;
        this.VelocidadeMaxima = this.VelocidadeMaximaOriginal;

        //this.HitboxAtor.DanoOriginal = 5;
        //this.HitboxAtor.Dano = this.HitboxAtor.DanoOriginal;

        this.DemoraAntesAtaqueOriginal = 0.5f;
        this.DemoraAntesAtaque = this.DemoraAntesAtaqueOriginal;
        this.DemoraDepoisAtaqueOriginal = 0.5f;
        this.DemoraDepoisAtaque = this.DemoraDepoisAtaqueOriginal;
        this.AlcanceAtaque = 0.16f;

        //this.VidaTotalOriginal = 100;
		this.VidaTotalOriginal = 20;
        this.VidaTotal = this.VidaTotalOriginal;
        this.VidaAtual = this.VidaTotalOriginal;

		ataque1.Dano = 5;
		ataque1.PosicaoRelativaInicial = new Vector3(0, 1f);
		ataque1.Velocidade = 1f;
		ataque1.DuracaoAtaque = 5f;
		ataque1.Cooldown = 1f;

		ataque2.Dano = 5;
		ataque2.PosicaoRelativaInicial = new Vector3(0, 1f);
		ataque2.Velocidade = 1f;
		ataque2.DuracaoAtaque = 5f;
		ataque2.Cooldown = 0.5f;

		ataque3.Dano = 5;
		ataque3.PosicaoRelativaInicial = new Vector3(0, 1f);
		ataque3.Velocidade = 1f;
		ataque3.DuracaoAtaque = 5f;
		ataque3.Cooldown = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (estadoAtual)
        {
            default:

                break;
            case IDLE:

                break;
            case PAUSA1:
				if (tempoPassadoPausa <= duracaoPausa)
                {
					tempoPassadoPausa += Time.deltaTime;
                }
                else
                {
                    tempoPassadoPausa = 0;
                    estadoAtual = ATAQUE1;
                }

                break;
            case ATAQUE1:
                if (tempoPassadoAtacando <= duracaoAtacando)
                {
					tempoPassadoAtacando += Time.deltaTime;
					ficarAtacando (ataque1);
                }
                else
                {
                    tempoPassadoAtacando = 0;

                    if (this.vidaAtual <= (this.VidaTotalOriginal / 4))
                    {
                        estadoAtual = PAUSA2;
                    }
                    else
                    {
                        estadoAtual = LEVITARBAIXO;
                    }
                }

                break;
            case PAUSA2:
				if (tempoPassadoPausa <= duracaoPausa)
                {
					tempoPassadoPausa += Time.deltaTime;
                }
                else
                {
                    tempoPassadoPausa = 0;
                    estadoAtual = ATAQUE2;
                }

                break;
            case ATAQUE2:
                if (tempoPassadoAtacando <= duracaoAtacando)
                {
					tempoPassadoAtacando += Time.deltaTime;
					ficarAtacando (ataque2);
                }
                else
                {
                    tempoPassadoAtacando = 0;
                    estadoAtual = LEVITARBAIXO;
                }

                break;
            case LEVITARBAIXO:
                estadoAtual = PAUSABAIXO;

                break;
            case PAUSABAIXO:
				if (tempoPassadoPausa <= duracaoPausa)
                {
					tempoPassadoPausa += Time.deltaTime;
                }
                else
                {
                    tempoPassadoPausa = 0;
                    estadoAtual = ATAQUEBAIXO;
                }

                break;
            case ATAQUEBAIXO:
                if (tempoPassadoAtacando <= duracaoAtacando)
                {
					tempoPassadoAtacando += Time.deltaTime;
					ficarAtacando (ataque3);
                }
                else
                {
                    tempoPassadoAtacando = 0;
                    estadoAtual = SUPERVULNERAVEL;
                }

                break;
            case SUPERVULNERAVEL:
                if (tempoPassadoSuperVulneravel <= duracaoSuperVulneravel)
                {
					tempoPassadoSuperVulneravel += Time.deltaTime;
                }
                else
                {
                    tempoPassadoSuperVulneravel = 0;
                    estadoAtual = PAUSAREPELIR;
                }

                break;
            case PAUSAREPELIR:
                if (tempoPassadoPausa <= duracaoPausa)
                {
					tempoPassadoPausa += Time.deltaTime;
                }
                else
                {
                    tempoPassadoPausa = 0;
                    estadoAtual = REPELIR;
                }

                break;
            case REPELIR:
                estadoAtual = LEVITARALTO;

                break;
		case LEVITARALTO:
				/*levitar (this.PosicaoSpawn);

				if (this.transform.position.Equals(this.PosicaoSpawn)) 
				{
                	estadoAtual = PAUSA1;
				}*/
				estadoAtual = PAUSA1;

                break;
        }
    }

	#region getters e setters
	public int EstadoAtual
	{
		get { return estadoAtual; }
		set { estadoAtual = value; }
	}

	public float DuracaoPausa
	{
		get { return duracaoPausa; }
		set { duracaoPausa = value; }
	}

	public float DuracaoAtacando
	{
		get { return duracaoAtacando; }
		set { duracaoAtacando = value; }
	}

	public float DuracaoSuperVulneravel
	{
		get { return duracaoSuperVulneravel; }
		set { duracaoSuperVulneravel = value; }
	}
	#endregion

    #region acoes
    public void comecarLuta()
    {
        estadoAtual = PAUSA1;
    }
		
	public void ficarAtacando (TiroInimigo ataque)
	{
		if (ataque.TempoPassadoCooldown < ataque1.Cooldown)
		{
			ataque.TempoPassadoCooldown += Time.deltaTime;
		}
		else
		{
			ataque.TempoPassadoCooldown = 0;
			ataque.Atirador = this.GetComponent<Inimigo>();
			Instantiate(ataque, ataque.transform.position, new Quaternion());
		}
	}

	public void levitar(Vector2 destino)
    {
		Vector2.MoveTowards (this.transform.position, destino, 4 * Time.deltaTime);
    }
    #endregion

	#region alteracao de status
	public void alterarVida(int valor)   
	{
		int resultadoFinal = this.VidaAtual + valor;

		if (valor < 0 && tempoPassadoSuperVulneravel > 0)
		{
			valor *= 3;
		}

		if (valor < 0 && this.IsImuneDano)
		{
			valor = 0;
			resultadoFinal = this.VidaAtual;
		}

		if (resultadoFinal > this.VidaTotal)
		{
			this.VidaAtual = this.VidaTotal;
		}
		else if (resultadoFinal < this.VidaAtual && resultadoFinal > 0)
		{
			this.AnimadorAtor.SetTrigger("ferido");
			this.AnimadorAtor.SetBool("atordoado", true);
			this.VidaAtual += valor;
			this.IsAtordoado = true;
		}
		else if (resultadoFinal <= 0 && !this.IsImuneDano)
		{
			morrer();
		}
		else
		{
			this.VidaAtual += valor;
		}
	}

	//mata o boss
	public virtual void morrer()
	{
		base.morrer ();
		this.AudioSourceAtor.PlayOneShot(morte, 5f); //morte
		Destroy(this.gameObject, 0.8f);
	}
	#endregion
}
