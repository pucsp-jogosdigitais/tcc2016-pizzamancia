using UnityEngine;
using System.Collections;

public class Boss : Inimigo
{
    #region atributos
    float metadeAlturaBoss;

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

    public int fatorVulnerabilidade = 2;

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
    public TiroBoss ataque1;
    public TiroBoss ataque2;
    public TiroBoss ataque3;

    //campos magicos
    public EscudoBoss escudo;
    #endregion

    // Use this for initialization
    void Start()
    {
        base.Start();

        metadeAlturaBoss = (this.GetComponent<Renderer>().bounds.size.y) + 0.1f;

        this.VelocidadeMaximaOriginal = 4f;
        this.VelocidadeMaxima = this.VelocidadeMaximaOriginal;

        this.VidaTotalOriginal = 200;
        this.VidaTotal = this.VidaTotalOriginal;
        this.VidaAtual = this.VidaTotalOriginal;

        this.DuracaoAtordoamento = 0.25f;

        this.Pontos = 0;

        this.TempoMorte = 2.6f;

        estadoAtual = IDLE;

        duracaoPausa = 2f;
        tempoPassadoPausa = 0;
        duracaoAtacando = 5f;
        tempoPassadoAtacando = 0;
        duracaoVulneravel = 4f;
        tempoPassadoVulneravel = 0;

        destino = new Vector2(0, 0);

        ataque1.PosicaoRelativaInicial = new Vector3(0, 1f);
        ataque1.TempoPassadoCooldown = 0;
        ataque2.PosicaoRelativaInicial = new Vector3(0, 1f);
        ataque2.TempoPassadoCooldown = 0;
        ataque3.PosicaoRelativaInicial = new Vector3(0, 1f);
        ataque3.TempoPassadoCooldown = 0;

        escudo.desativar();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.VidaAtual > 0)
        {
            RaycastHit2D raycastCentroBoss = Physics2D.Raycast(this.transform.position, Vector2.down);

            if (raycastCentroBoss.distance <= metadeAlturaBoss)
            {
                isNoChao = true;
            }
            else
            {
                isNoChao = false;
            }

            if (this.IsAtordoado)
            {
                if (this.TempoAtordoadoPassado < this.DuracaoAtordoamento)
                {
                    this.TempoAtordoadoPassado += Time.deltaTime;
                }
                else
                {
                    this.AnimadorAtor.SetBool("atordoado", false);
                    this.IsAtordoado = false;
                    this.TempoAtordoadoPassado = 0;
                }
            }
            else
            {
                if ((this.Alvo.transform.position.x - this.transform.position.x) < -0.1f)
                {
                    this.transform.localScale = new Vector2(-1, this.transform.localScale.y);
                }
                else if ((this.Alvo.transform.position.x - this.transform.position.x) > 0.1f)
                {
                    this.transform.localScale = new Vector2(1, this.transform.localScale.y);
                }
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
                        this.AnimadorAtor.SetBool("conjurar", false);

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
                        this.AnimadorAtor.SetBool("conjurar", false);
                        estadoAtual = LEVITARBAIXO;
                    }

                    break;
                case LEVITARBAIXO:
                    if (destino.Equals(new Vector2(0, 0)))
                    {
                        if (Random.Range(0, 2) == 0)
                        {
                            destino = new Vector2(24.5f, 4.55f);
                        }
                        else
                        {
                            destino = new Vector2(33f, 4.55f);
                        }

                        this.AnimadorAtor.SetTrigger("flutuar");
                    }
                    else
                    {
                        levitar(destino);

                        if (waypointBaixo1.IsBossChegou || waypointBaixo2.IsBossChegou)
                        {
                            destino = new Vector2(0, 0);
                            this.AnimadorAtor.SetBool("chegouWaypoint", true);
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
                        escudo.desativar();
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
                        this.AnimadorAtor.SetBool("conjurar", false);
                        estadoAtual = VULNERAVEL;
                    }

                    break;
                case VULNERAVEL:
                    if (tempoPassadoVulneravel <= duracaoVulneravel)
                    {
                        tempoPassadoVulneravel += Time.deltaTime;
                    }
                    else
                    {
                        tempoPassadoVulneravel = 0;
                        escudo.prepararAtivacao();
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
                        escudo.ativar();
                        estadoAtual = LEVITARALTO;
                    }

                    break;
                case LEVITARALTO:
                    if (destino.Equals(new Vector2(0, 0)))
                    {
                        destino = this.PosicaoSpawn;
                        this.AnimadorAtor.SetTrigger("flutuar");
                    }
                    else
                    {
                        levitar(this.PosicaoSpawn);

                        if (waypointCima.IsBossChegou)
                        {
                            destino = new Vector2(0, 0);
                            this.AnimadorAtor.SetBool("chegouWaypoint", true);
                            estadoAtual = PAUSA1;
                        }
                    }

                    break;
            }
        }
    }

    void OnDestroy()
    {
        GameManager.getInstance().IsLevelCompleto = true;
    }

    #region acoes
    public void comecarLuta()
    {
        estadoAtual = PAUSA1;
        escudo.prepararAtivacao();
        escudo.ativar();
    }

    public void ficarAtacando(TiroBoss ataque)
    {
        this.AnimadorAtor.SetBool("conjurar", true);

        if (ataque.TempoPassadoCooldown < ataque1.Cooldown)
        {
            ataque.TempoPassadoCooldown += Time.deltaTime;
        }
        else
        {
            if (!this.IsAtordoado)
            {
                this.AnimadorAtor.SetBool("conjurar", false);
                ataque.TempoPassadoCooldown = 0;
                Instantiate(ataque, ataque.transform.position, new Quaternion());
            }
        }
    }

    public void levitar(Vector2 destino)
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, destino, this.VelocidadeMaxima / 100);
    }
    #endregion

    #region alteracao de status
    //mata o boss
    public override void morrer()
    {
        this.AnimadorAtor.SetBool("atordoado", false);
        this.AnimadorAtor.SetBool("morto", true);
        this.VidaAtual = 0;
        this.IsImuneDano = true;

        this.AudioSourceAtor.PlayOneShot(morte, 2f); //morte
        Destroy(this.gameObject, tempoMorte);
    }
    #endregion
}
