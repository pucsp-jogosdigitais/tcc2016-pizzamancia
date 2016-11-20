using UnityEngine;
using System.Collections;

public class Ator : MonoBehaviour
{
    //essa classe serve para representar caracteristicas básicas de
    //todos os personagens do game, funcionando como uma classe-pai para
    //as demais classes que serao responsaveis pelo funcionamento de
    //personagens jogaveis, NPC's, mobs e bosses

    #region atributos
    //animacao
    public Animator animadorAtor; //animator do ator

    //Rigidbody e colisao
    public Rigidbody2D rdbAtor; //rigidbody do ator

    //audio
    AudioSource audioSourceAtor; //audiosource do ator
    public AudioClip clip;

    //ponto de spawn
    public Vector2 posicaoSpawn; //posicao onde o ator (re)comeca

    //movimentacao
    float metadeLargura; //distancia entre as bordas verticais do ator e o seu centro
    float metadeAltura; //distancia entre as bordas horizontais do ator e o seu centro
	public RaycastHit2D raycastCentro;
    float movimentoX; //movimento do ator no eixo X
    public float velocidadeMaximaOriginal; //velocida maxima que o ator pode atingir andando
    public float velocidadeMaxima; //velocidade maxima atual
    bool isNoChao; //booleana que mostra se ator esta colidindo com o chao ou nao

    //ataque melee
    public Hitbox hitboxAtor; //hitbox respectiva do ator
    bool isComecouAtaque; //booleana que indica se o ator comecou o processo de ataque ou nao
    bool isAtacou; //booleana que indica se ator ja executou taque
    public float demoraAntesAtaqueOriginal; //tempo que demora entre o inicio do ataque a sua execucao
    public float demoraAntesAtaque; //demora antes da execucao do ataque atual
    public float demoraDepoisAtaqueOriginal; //tempo que demora entre a execucao do ataque e a sua finalizacao
    public float demoraDepoisAtaque; //demora depois da execucao do ataque atual
    float tempoPassadoInicioAtaque; //tempo passado desde o inicio do ataque

    //vida
    public int vidaTotalOriginal; //quantos pontos de vida o ator tem no total
    public int vidaTotal; //quantos pontos de vida o ator tem no total atual
    public int vidaAtual; //quantos pontos de vida o ator tem no momento

    //atordoamento
    public bool isAtordoado; //condicao que indica se o ator fica atordoado(incapaz de realizar acoes) quando leva dano
    public float duracaoAtordoamento; //quanto tempo o ator fica atordoado cada vez que leva dano
    float tempoAtordoadoPassado; //quanto tempo se passou desde o inicio do atordoamento

    //buffs e debuffs
    public bool isImuneDano;
    #endregion

    void Awake()
    {
        animadorAtor = this.GetComponent<Animator>();

        rdbAtor = this.GetComponent<Rigidbody2D>();

        audioSourceAtor = GameObject.Find("Audio ambiente").GetComponent<AudioSource>();

        posicaoSpawn = this.transform.position;
        metadeLargura = this.GetComponent<Renderer>().bounds.size.x / 4;
        metadeAltura = (this.GetComponent<Renderer>().bounds.size.y) + 0.1f;

        isComecouAtaque = false;
        isAtacou = false;
        tempoPassadoInicioAtaque = 0;

        isAtordoado = false;
        tempoAtordoadoPassado = 0;
    }

    void FixedUpdate()
    {
        Vector2 ladoEsq = new Vector2(this.transform.position.x - metadeLargura, this.transform.position.y);
        Vector2 ladoDir = new Vector2(this.transform.position.x + metadeLargura, this.transform.position.y);
        RaycastHit2D raycastEsq = Physics2D.Raycast(ladoEsq, Vector2.down);
        raycastCentro = Physics2D.Raycast(this.transform.position, Vector2.down);
        RaycastHit2D raycastDir = Physics2D.Raycast(ladoDir, Vector2.down);

        if ((raycastEsq.distance <= metadeAltura) || (raycastCentro.distance <= metadeAltura) ||
            (raycastDir.distance <= metadeAltura))
        {
            isNoChao = true;
        }
        else
        {
            isNoChao = false;
        }

        if (isAtordoado)
        {
            movimentoX = 0;
            terminarAtaque();

            if (tempoAtordoadoPassado < duracaoAtordoamento)
            {
                tempoAtordoadoPassado += Time.deltaTime;
            }
            else
            {
                animadorAtor.SetBool("atordoado", false);
                isAtordoado = false;
                tempoAtordoadoPassado = 0;
            }
        }
        else
        {
            if (isComecouAtaque)
            {
                movimentoX = 0;
                tempoPassadoInicioAtaque += Time.deltaTime;

                if (tempoPassadoInicioAtaque >= demoraAntesAtaque && !isAtacou)
                {
                    executarAtaque();
                }

                if (tempoPassadoInicioAtaque >= (demoraAntesAtaque + demoraDepoisAtaque))
                {
                    terminarAtaque();
                }
            }

            andar();
        }
    }

    #region getters e setters
    public Animator AnimadorAtor
    {
        get { return animadorAtor; }
        set { animadorAtor = value; }
    }

    public Rigidbody2D RdbAtor
    {
        get { return rdbAtor; }
        set { rdbAtor = value; }
    }

    public AudioSource AudioSourceAtor
    {
        get { return audioSourceAtor; }
        set { audioSourceAtor = value; }
    }

    public Vector2 PosicaoSpawn
    {
        get { return posicaoSpawn; }
        set { posicaoSpawn = value; }
    }

    public float MovimentoX
    {
        get { return movimentoX; }
        set { movimentoX = value; }
    }

    public float VelocidadeMaximaOriginal
    {
        get { return velocidadeMaximaOriginal; }
        set { velocidadeMaximaOriginal = value; }
    }

    public float VelocidadeMaxima
    {
        get { return velocidadeMaxima; }
        set { velocidadeMaxima = value; }
    }

    public bool IsNoChao
    {
        get { return isNoChao; }
        set { isNoChao = value; }
    }

    public Hitbox HitboxAtor
    {
        get { return hitboxAtor; }
        set { hitboxAtor = value; }
    }

    public bool IsComecouAtaque
    {
        get { return isComecouAtaque; }
        set { isComecouAtaque = value; }
    }

    public float DemoraAntesAtaqueOriginal
    {
        get { return demoraAntesAtaqueOriginal; }
        set { demoraAntesAtaqueOriginal = value; }
    }

    public float DemoraAntesAtaque
    {
        get { return demoraAntesAtaque; }
        set { demoraAntesAtaque = value; }
    }

    public float DemoraDepoisAtaqueOriginal
    {
        get { return demoraDepoisAtaqueOriginal; }
        set { demoraDepoisAtaqueOriginal = value; }
    }

    public float DemoraDepoisAtaque
    {
        get { return demoraDepoisAtaque; }
        set { demoraDepoisAtaque = value; }
    }

    public int VidaTotalOriginal
    {
        get { return vidaTotalOriginal; }
        set { vidaTotalOriginal = value; }
    }

    public int VidaTotal
    {
        get { return vidaTotal; }
        set { vidaTotal = value; }
    }

    public int VidaAtual
    {
        get { return vidaAtual; }
        set { vidaAtual = value; }
    }

    public bool IsAtordoado
    {
        get { return isAtordoado; }
        set { isAtordoado = value; }
    }

    public float DuracaoAtordoamento
    {
        get { return duracaoAtordoamento; }
        set { duracaoAtordoamento = value; }
    }

    public bool IsImuneDano
    {
        get { return isImuneDano; }
        set { isImuneDano = value; }
    }
    #endregion

    #region acoes
    //faz o ator andar
    public void andar()
    {
        animadorAtor.SetFloat("andar", Mathf.Abs(movimentoX));

        if (movimentoX > 0)
        {
            this.transform.localScale = new Vector2(1, this.transform.localScale.y);
        }

        if (movimentoX < 0)
        {
            this.transform.localScale = new Vector2(-1, this.transform.localScale.y);
        }

        rdbAtor.AddForce(new Vector2(movimentoX, 0) * (15 / (rdbAtor.velocity.magnitude + 1f)));

        if (Mathf.Abs(rdbAtor.velocity.x) > velocidadeMaxima)
        {
            rdbAtor.velocity = new Vector2(rdbAtor.velocity.normalized.x * velocidadeMaxima, rdbAtor.velocity.y);
        }
    }

    //comeca processo de execucao do ataque
    public void comecarAtaque(bool isAtacar)
    {
        if (isAtacar && !isComecouAtaque)
        {
            isComecouAtaque = true;
        }
    }

    //executa ataque
    public void executarAtaque()
    {
        animadorAtor.SetTrigger("atacar");
        isAtacou = true;
        hitboxAtor.atingir();
    }

    //termina o processo de execucao de ataque
    public void terminarAtaque()
    {
        isComecouAtaque = false;
        isAtacou = false;
        tempoPassadoInicioAtaque = 0;
    }
    #endregion

    #region alteracao de status
    //aumenta ou diminui os pontos de vida atual
    public void alterarVida(int valor)
    {
        int resultadoFinal = vidaAtual + valor;

        if (resultadoFinal < vidaAtual && isImuneDano)
        {
            valor = 0;
            resultadoFinal = vidaAtual;
        }

        if (resultadoFinal > vidaTotal)
        {
            vidaAtual = vidaTotal;
        }
        else if (resultadoFinal < vidaAtual && resultadoFinal > 0)
        {
            animadorAtor.SetTrigger("ferido");
            animadorAtor.SetBool("atordoado", true);
            vidaAtual += valor;
            isAtordoado = true;
        }
        else if (resultadoFinal <= 0 && !isImuneDano)
        {
            morrer();
        }
        else
        {
            vidaAtual += valor;
        }
    }

    //mata (destroi) o ator
    public virtual void morrer()
    {
        animadorAtor.SetBool("atordoado", false);
        animadorAtor.SetBool("morto", true);
        movimentoX = 0;
        vidaAtual = 0;
        isImuneDano = true;

        terminarAtaque();
    }
    #endregion
}
