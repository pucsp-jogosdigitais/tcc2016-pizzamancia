﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inimigo : Ator
{
    #region atributos
    //audio
    public AudioClip morte;
    public AudioClip hit;

    //movimentacao de vagar
    //public Vector2 posicaoCentroVagar;
    //public float alcanceCentroVagar;

    //perseguicao de jogador
    float raioPercepcao;
    bool isDetectou;
    Jogador alvo;
    float distanciaInimigoJogador;

    //ataque
    float alcanceAtaque;

    //pontos
    int pontos;

	public float tempoMorte;
    #endregion

    protected void Start()
    {
        this.MovimentoX = 0; //= -1;

        //posicaoCentroVagar = this.PosicaoSpawn;

        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
    }

    // Update is called once per frame
    void Update()
    {
        distanciaInimigoJogador = Vector2.Distance(alvo.transform.position, this.transform.position);

        vigiar();

        if (isDetectou)
        {
            perseguirJogador();

            if (distanciaInimigoJogador < alcanceAtaque)
            {
                this.comecarAtaque(true);
            }
        }
    }

    #region getters e setters
    public float RaioPercepcao
    {
        get { return raioPercepcao; }
        set { raioPercepcao = value; }
    }

    public bool IsDetectou
    {
        get { return isDetectou; }
        set { isDetectou = value; }
    }

    public Jogador Alvo
    {
        get { return alvo; }
        set { alvo = value; }
    }

    public float DistanciaInimigoJogador
    {
        get { return distanciaInimigoJogador; }
        set { distanciaInimigoJogador = value; }
    }

    public float AlcanceAtaque
    {
        get { return alcanceAtaque; }
        set { alcanceAtaque = value; }
    }

    public int Pontos
    {
        get { return pontos; }
        set { pontos = value; }
    }

	public float TempoMorte
	{
		get { return tempoMorte; }
		set { tempoMorte = value; }
	}
    #endregion

    #region acoes automaticas
    public void vigiar()
    {
        if (distanciaInimigoJogador <= raioPercepcao)
        {
            isDetectou = true;
        }
        else
        {
            isDetectou = false;
        }
    }
    #endregion

    /*#region eventos de colisao
    void OnCollisionEnter2D(Collision2D colisao)
    {
        Collider2D colisor = colisao.collider;

        if ((colisor.gameObject.tag.ToString() != "Player") &&
            (colisor.gameObject.tag.ToString() != "Inimigo") &&
            (colisor.gameObject.tag.ToString() != "Hitbox") &&
            (colisor.gameObject.tag.ToString() != "Headbox") &&
            (colisor.gameObject.tag.ToString() != "PowerUp") &&
            (colisor.gameObject.tag.ToString() != "Ponto") &&
            (colisor.gameObject.tag.ToString() != "Obstaculo") &&
            (colisor.gameObject.tag.ToString() != "AtaqueMagico"))
        {
            Vector2 pontoCentral = new Vector2(this.GetComponent<Renderer>().bounds.center.x, this.GetComponent<Renderer>().bounds.center.y);
            Vector2 pontoContato = colisao.contacts[0].point;

            if (pontoContato.x < pontoCentral.x)
            {
                this.MovimentoX = 1;
            }
            else if (pontoContato.x > pontoCentral.x)
            {
                this.MovimentoX = -1;
            }
        }
    }
    #endregion*/

    #region acoes basicas
    public void perseguirJogador()
    {
        if ((alvo.transform.position.x - this.transform.position.x) < -0.1f)
        {
            this.MovimentoX = -1;
            //posicaoCentroVagar = new Vector2(this.transform.position.x + alcanceCentroVagar, this.transform.position.y);
        }
        else if ((alvo.transform.position.x - this.transform.position.x) > 0.1f)
        {
            this.MovimentoX = 1;
            //posicaoCentroVagar = new Vector2(this.transform.position.x - alcanceCentroVagar, this.transform.position.y);
        }
        else
        {
            this.MovimentoX = 0;
            //posicaoCentroVagar = new Vector2(this.transform.position.x, this.transform.position.y);
        }
    }

    //public void vagar()
    //{
    //    if ((Vector2.Distance(this.transform.position, posicaoCentroVagar) > alcanceCentroVagar))
    //    {
    //        this.MovimentoX *= -1;
    //    }
    //}
    #endregion

    #region alteracao de status
    public override void morrer()
    {
        base.morrer();
        this.AudioSourceAtor.PlayOneShot(morte, 2f); //morte
        GameManager.getInstance().alterarPontos(pontos);
        Destroy(this.gameObject, tempoMorte);
    }
    #endregion
}
