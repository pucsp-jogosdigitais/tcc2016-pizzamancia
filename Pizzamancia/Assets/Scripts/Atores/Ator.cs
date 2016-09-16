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

    //movimentacao
	public Vector2 posicaoSpawn; //posicao onde o ator (re)comeca
	float metadeLargura; //distancia entre as bordas verticais do ator e o seu centro
	float metadeAltura; //distancia entre as bordas horizontais do ator e o seu centro
    Vector2 ladoEsq; //local do ponto-medio da borda horizontal esquerda do ator
	Vector2 ladoDir; //local do ponto-medio da borda horizontal direita do ator
    RaycastHit2D raycastEsq; //linha tracada entre o ladoEsq e o chao
	RaycastHit2D raycastCentro; //linha tracada entre o centro do ator e o chao
	RaycastHit2D raycastDir; //linha tracada entre o ladoDir e o chao
    float movimentoX; //movimento do ator no eixo X
    public float velocidade; //velocidade com a qual o ator se move
    public bool isNoChao; //booleana que mostra se ator esta colidindo com o chao ou nao
    public float forcaPulo; //forca do pulo
	float distanciaLadoEsqChao;
	float distanciaCentroChao;
	float distanciaLadoDirChao;

    //ataque melee
    public bool isComecouAtaque; //booleana que indica se o ator comecou o processo de ataque ou nao
	public bool isAtacou; //booleana que indica se ator ja executou taque
    public Hitbox hitboxAtor;
    public float demoraAntesAtaque; //tempo que demora entre o inicio do ataque a sua execucao
	public float demoraDepoisAtaque; //tempo que demora entre a execucao do ataque e a sua finalizacao
    float tempoPassadoInicioAtaque; //tempo passado desde o inicio do ataque

    //vida
    public int vidaTotal; //quantos pontos de vida o ator tem no total
    public int vidaAtual; //quantos pontos de vida o ator tem no momento
    #endregion

    void Awake()
    {
        animadorAtor = this.GetComponent<Animator>();

        rdbAtor = this.GetComponent<Rigidbody2D>();

        posicaoSpawn = this.transform.position;
		metadeLargura = this.GetComponent<Renderer>().bounds.size.x / 4;
		metadeAltura = (this.GetComponent<Renderer>().bounds.size.y / 2) + 0.1f;

        isComecouAtaque = false;
		isAtacou = false;
        tempoPassadoInicioAtaque = 0;
    }

    void FixedUpdate()
    {
        ladoEsq = new Vector2(this.transform.position.x - metadeLargura, this.transform.position.y);
        ladoDir = new Vector2(this.transform.position.x + metadeLargura, this.transform.position.y);
        raycastEsq = Physics2D.Raycast(ladoEsq, Vector2.down);
		raycastCentro = Physics2D.Raycast(this.transform.position, Vector2.down);
        raycastDir = Physics2D.Raycast(ladoDir, Vector2.down);
		Debug.DrawRay(ladoEsq, Vector2.down);
		Debug.DrawRay(this.transform.position, Vector2.down);
		Debug.DrawRay(ladoDir, Vector2.down);
		distanciaLadoEsqChao = raycastEsq.distance;
		distanciaCentroChao = raycastCentro.distance;
		distanciaLadoDirChao = raycastDir.distance;

		if ((raycastEsq.distance <= metadeAltura) || (raycastCentro.distance <= metadeAltura) || (raycastDir.distance <= metadeAltura))
        {
            isNoChao = true;
        }
        else
        {
            isNoChao = false;
        }

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

    public float Velocidade
    {
        get { return velocidade; }
        set { velocidade = value; }
    }

    public bool IsNoChao
    {
        get { return isNoChao; }
        set { isNoChao = value; }
    }

    public float ForcaPulo
    {
        get { return forcaPulo; }
        set { forcaPulo = value; }
    }

    public bool IsComecouAtaque
    {
        get { return isComecouAtaque; }
        set { isComecouAtaque = value; }
    }

	public bool IsAtacou 
	{
		get { return isAtacou; }
		set { isAtacou = value; }
	}

    public Hitbox HitboxAtor
    {
        get { return hitboxAtor; }
        set { hitboxAtor = value; }
    }

    public float DemoraAntesAtaque
    {
        get { return demoraAntesAtaque; }
        set { demoraAntesAtaque = value; }
    }

    public float DemoraDepoisAtaque
    {
        get { return demoraDepoisAtaque; }
        set { demoraDepoisAtaque = value; }
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
    #endregion

    #region acoes
    //faz o ator andar
    public void andar()
    {
        animadorAtor.SetFloat("andar", Mathf.Abs(movimentoX));

        if (movimentoX > 0)
        {
            this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        }

        if (movimentoX < 0)
        {
            this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
        }

        rdbAtor.velocity = new Vector2(movimentoX * velocidade, rdbAtor.velocity.y);
    }
		
	//faz o ator pular
    public void pular(bool isPular)
	{
		if (isPular && isNoChao)
        {
            animadorAtor.SetTrigger("pular");
            rdbAtor.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
        }
    }

    public void comecarAtaque(bool isAtacar)
    {
        if (isAtacar && !isComecouAtaque)
        {
            animadorAtor.SetTrigger("atacar");
            isComecouAtaque = true;
        }
    }
    #endregion

    #region alteracao de status
    public void executarAtaque()
    {
		isAtacou = true;

        hitboxAtor.atingir();
    }

    public void terminarAtaque()
    {
        isComecouAtaque = false;
		isAtacou = false;
        tempoPassadoInicioAtaque = 0;
    }

	//aumenta ou diminui os pontos de vida atual
    public void alterarVida(int valor)
    {
        int resultadoFinal = vidaAtual + valor;

        if (resultadoFinal > vidaTotal)
        {
            vidaAtual = vidaTotal;
        }
        else if (resultadoFinal <= 0)
        {
            vidaAtual = 0;
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
    }
    #endregion
}
