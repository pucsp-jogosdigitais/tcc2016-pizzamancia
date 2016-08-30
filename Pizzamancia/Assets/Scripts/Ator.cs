﻿using UnityEngine;
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
	float metadeLargura;
	float distanciaCentroChao;
	Vector3 ladoEsq;
	Vector3 ladoDir;
	RaycastHit2D raycastEsq;
	RaycastHit2D raycastCentro;
	RaycastHit2D raycastDir;
    public float movimentoX; //movimento do ator no eixo X
    public float velocidade; //velocidade com a qual o ator se move
    public bool isNoChao; //booleana que mostra se ator esta colidindo com o chao ou nao
    public float forcaPulo; //forca do pulo

    //vida
    public int vidaTotal; //quantos pontos de vida o ator tem no total
    public int vidaAtual; //quantos pontos de vida o ator tem no momento

	//ataque melee
	public int danoAtaque;
	public float delayAtaque;
	public float forcaRecuo;
    #endregion

	void Awake () {
		animadorAtor = this.GetComponent<Animator> ();

		rdbAtor = this.GetComponent<Rigidbody2D> ();

		metadeLargura = this.GetComponent<Renderer> ().bounds.size.x / 2;
		distanciaCentroChao = (this.GetComponent<Renderer> ().bounds.size.y / 2) + 0.5f;
	}

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
		ladoEsq = new Vector3(this.transform.position.x - metadeLargura, this.transform.position.y, this.transform.position.z);
		ladoDir = new Vector3(this.transform.position.x + metadeLargura, this.transform.position.y, this.transform.position.z);
		raycastEsq = Physics2D.Raycast(ladoEsq, Vector2.down);
		raycastCentro = Physics2D.Raycast (this.transform.position, Vector2.down);
		raycastDir = Physics2D.Raycast(ladoDir, Vector2.down);
        //Debug.DrawRay(ladoEsq, Vector3.down);
		//Debug.DrawRay(this.transform.position, Vector3.down);
        //Debug.DrawRay(ladoDir, Vector3.down);

		if ((raycastEsq.distance <= distanciaCentroChao) || (raycastCentro.distance <= distanciaCentroChao) || (raycastDir.distance < distanciaCentroChao))
        {
            isNoChao = true;
        }
        else
        {
            isNoChao = false;
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

	public int DanoAtaque
	{
		get { return danoAtaque; }
		set { danoAtaque = value; }
	}

	public float DelayAtauqe
	{
		get { return delayAtaque; }
		set { delayAtaque = value; }
	}

	public float ForcaRecuo
	{
		get { return forcaRecuo; }
		set { forcaRecuo = value; }
	}
    #endregion

    #region acoes
	//faz o ator andar
    public void andar()
    {
        //animadorAtor.SetFloat("andar", Mathf.Abs(movimentoX));

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
            //animadorAtor.SetTrigger ("pular");
            rdbAtor.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
        }
    }

	public void atacar (bool isAtacar) {
	
	}
    #endregion

    #region alteracao de status
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
