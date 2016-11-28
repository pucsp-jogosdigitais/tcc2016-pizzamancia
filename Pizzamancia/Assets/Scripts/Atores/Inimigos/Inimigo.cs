using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inimigo : Ator
{
    #region atributos
    //audio
    public AudioClip morte;
    public AudioClip hit;

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
        this.MovimentoX = 0;

        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
    }

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

    #region acoes basicas
    public void perseguirJogador()
    {
        if ((alvo.transform.position.x - this.transform.position.x) < -0.1f)
        {
            this.MovimentoX = -1;
        }
        else if ((alvo.transform.position.x - this.transform.position.x) > 0.1f)
        {
            this.MovimentoX = 1;
        }
        else
        {
            this.MovimentoX = 0;
        }
    }
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
