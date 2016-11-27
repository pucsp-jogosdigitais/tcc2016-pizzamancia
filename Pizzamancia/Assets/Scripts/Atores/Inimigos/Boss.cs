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
	const int VULNERAVEL = 7;
    const int PAUSAREEPELIR = 8;
    const int LEVITARALTO = 9;

    //duracao e tempo passado nos estados
	public float duracaoPausa;
    float tempoPassadoPausa;
	public float duracaoAtacando;
    float tempoPassadoAtacando;
	public float duracaoVulneravel;
    float tempoPassadoVulneravel;

	//waypoints
	public WaypointBoss waypointCima;
	public WaypointBoss waypointBaixo1;
	public WaypointBoss waypointBaixo2;

	//destino da levitacao
	public Vector2 destino;

    //ataques
    public TiroInimigo ataque1;
    public TiroInimigo ataque2;
    public TiroInimigo ataque3;

	//campos magicos
	public EscudoBoss escudo;
    #endregion

    // Use this for initialization
    void Start()
    {
        base.Start();

        estadoAtual = IDLE;

        duracaoPausa = 2f;
        tempoPassadoPausa = 0;
        duracaoAtacando = 5f;
        tempoPassadoAtacando = 0;
        duracaoVulneravel = 4f;
        tempoPassadoVulneravel = 0;

        this.VelocidadeMaximaOriginal = 4f;
        this.VelocidadeMaxima = this.VelocidadeMaximaOriginal;

        //this.VidaTotalOriginal = 100;
        this.VidaTotalOriginal = 20;
        this.VidaTotal = this.VidaTotalOriginal;
        this.VidaAtual = this.VidaTotalOriginal;

		destino = new Vector2(0, 0);

        ataque1.Dano = 5;
        ataque1.PosicaoRelativaInicial = new Vector3(0, 1f);
        ataque1.Velocidade = 1f;
        ataque1.DuracaoAtaque = 5f;
        ataque1.Cooldown = 1f;
		ataque1.TempoPassadoCooldown = 0;

        ataque2.Dano = 5;
        ataque2.PosicaoRelativaInicial = new Vector3(0, 1f);
       	ataque2.Velocidade = 2f;
        ataque2.DuracaoAtaque = 5f;
        ataque2.Cooldown = 0.5f;
		ataque2.TempoPassadoCooldown = 0;

        ataque3.Dano = 10;
        ataque3.PosicaoRelativaInicial = new Vector3(0, 1f);
        ataque3.Velocidade = 1f;
        ataque3.DuracaoAtaque = 5f;
        ataque3.Cooldown = 1f;
		ataque3.TempoPassadoCooldown = 0;

		escudo.desativar ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if ((this.Alvo.transform.position.x - this.transform.position.x) < -0.1f)
		{
			this.transform.localScale = new Vector2(-1, this.transform.localScale.y);
		}
		else if ((this.Alvo.transform.position.x - this.transform.position.x) > 0.1f)
		{
			this.transform.localScale = new Vector2(1, this.transform.localScale.y);
		}

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
                    ficarAtacando(ataque1);
                }
                else
                {
                    tempoPassadoAtacando = 0;

                    if (this.VidaAtual <= (this.VidaTotalOriginal / 4))
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
                    ficarAtacando(ataque2);
                }
                else
                {
                    tempoPassadoAtacando = 0;
                    estadoAtual = LEVITARBAIXO;
                }

                break;
			case LEVITARBAIXO:
				if (destino.Equals (new Vector2 (0, 0))) 
				{
					if (Random.Range(0, 2) == 0)
					{
						destino = new Vector2(24.5f, 4.55f);
					}
					else
					{
						destino = new Vector2(33f, 4.55f);
					}
				} 
				else 
				{
					levitarParaBaixo(destino);

					if (waypointBaixo1.IsBossChegou || waypointBaixo2.IsBossChegou)
					{
						destino = new Vector2 (0, 0);
						estadoAtual = PAUSABAIXO;
					}
				}
				
                break;
            case PAUSABAIXO:
                if (tempoPassadoPausa <= duracaoPausa)
                {
                    tempoPassadoPausa += Time.deltaTime;
                }
                else
                {
                    tempoPassadoPausa = 0;
					escudo.desativar ();
                    estadoAtual = ATAQUEBAIXO;
                }

                break;
            case ATAQUEBAIXO:
                if (tempoPassadoAtacando <= duracaoAtacando)
                {
                    tempoPassadoAtacando += Time.deltaTime;
                    ficarAtacando(ataque3);
                }
                else
                {
                    tempoPassadoAtacando = 0;
                    estadoAtual = VULNERAVEL;
                }

                break;
            case VULNERAVEL:
                if (tempoPassadoVulneravel <= duracaoVulneravel)
                {
                    tempoPassadoVulneravel += Time.deltaTime;
					print ("ORA!");
                }
                else
                {
                    tempoPassadoVulneravel = 0;
					escudo.prepararAtivacao ();
                    estadoAtual = PAUSAREEPELIR;
                }

                break;
			case PAUSAREEPELIR:
                if (tempoPassadoPausa <= duracaoPausa)
                {
                    tempoPassadoPausa += Time.deltaTime;
                }
                else
                {
                    tempoPassadoPausa = 0;
					escudo.ativar ();
					estadoAtual = LEVITARALTO;
                }

                break;
            case LEVITARALTO:
                levitarParaCima();

				if (waypointCima.IsBossChegou)
				{
					estadoAtual = PAUSA1;
				}

                break;
        }
    }

    #region acoes
    public void comecarLuta()
    {
        estadoAtual = PAUSA1;
		escudo.prepararAtivacao ();
		escudo.ativar ();
    }

    public void ficarAtacando(TiroInimigo ataque)
    {
        if (ataque.TempoPassadoCooldown < ataque1.Cooldown)
        {
           ataque.TempoPassadoCooldown += Time.deltaTime;
        }
        else
        {
			ataque.TempoPassadoCooldown = 0;
			Instantiate(ataque, ataque.transform.position, new Quaternion());
        }
    }

	public void levitarParaBaixo(Vector2 destino)
	{
		this.transform.position = Vector2.MoveTowards(this.transform.position, destino, this.VelocidadeMaxima / 100);
	}

    public void levitarParaCima()
    {
		this.transform.position = Vector2.MoveTowards(this.transform.position, this.PosicaoSpawn, this.VelocidadeMaxima / 100);
    }
    #endregion

    #region alteracao de status
    public void alterarVida(int valor)
    {
        int resultadoFinal = 0;

        if (valor < 0 && tempoPassadoVulneravel > 0)
        {
            valor *= 3;
        }

		resultadoFinal = this.VidaAtual + valor;

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
        base.morrer();
        this.AudioSourceAtor.PlayOneShot(morte, 5f); //morte
        Destroy(this.gameObject, 0.8f);
    }
    #endregion
}
