using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class Jogador : Ator
{
    #region atributos
    public bool isControlavel; //booleana que mostra se o jogador recebe input do controle

    //audio
    AudioSource audio;
    public AudioClip clip;

    //vida
    public int chances; //quantas chances o jogador tem no momento

    //mana
	public int manaTotalOriginal; //quantos pontos de mana o jogador tem no total
    public int manaTotal; //quantos pontos de mana o jogador tem no total atual
    public int manaAtual; //quantos pontos de mana o jogador tem no momento
    public int taxaRegeneracaoMana; //quantos pontos de mana sao regenerados apos um certo intervalo
    public float tempoRegeneracaoMana; //intervalo que demora para regenerar pontos de mana
    float tempoPassadoRegeneracao; //quanto tempo passou depois do ultimo intervalo de regeneracao de mana

    //magias
	public int qtdMagiasAlocadas; //quantas magias o jogador pode escolher para um level
	public Magia[] magias; //magias escolhidas para o level
	public int posicaoMagiaSelecionada; //posicao da magia no dictionary de magias
	public Magia magiaSelecionada; //magia selecionada no momento pelo jogador
	bool isComecouConjuracao; //booleana que indica se o jogador comecou a conjuracao de uma magia
	float demoraConjuracao; //tempo que demora para uma magia ser lancada apos o inicio da conjuracao
	float tempoPassadoInicioConjuracao; // tempo passado desde o inicio do processo de conjuracao
    #endregion

    // Use this for initialization
    void Start()
    {
        this.IsControlavel = true;

        audio = this.GetComponent<AudioSource>();

        this.VelocidadeMaximaOriginal = 3f;
        this.VelocidadeMaxima = this.VelocidadeMaximaOriginal;
        this.ForcaPuloOriginal = 6f;
        this.ForcaPulo = this.ForcaPuloOriginal;

        this.HitboxAtor.DanoOriginal = 2;
        this.HitboxAtor.Dano = this.HitboxAtor.DanoOriginal;
        this.HitboxAtor.ForcaRecuoOriginal = 4f;
        this.HitboxAtor.ForcaRecuo = this.HitboxAtor.ForcaRecuoOriginal;
        this.DemoraAntesAtaqueOriginal = 0.25f;
        this.DemoraAntesAtaque = this.demoraAntesAtaqueOriginal;
        this.DemoraDepoisAtaqueOriginal = 0.25f;
        this.DemoraDepoisAtaque = this.DemoraDepoisAtaqueOriginal;

        chances = 3;
        this.VidaTotalOriginal = 50;
        this.VidaTotal = this.VidaTotalOriginal;
        this.VidaAtual = this.VidaTotalOriginal;

        manaTotalOriginal = 100;
        manaTotal = manaTotalOriginal;
        manaAtual = manaTotalOriginal;
        taxaRegeneracaoMana = 10;
        tempoRegeneracaoMana = 1;
        tempoPassadoRegeneracao = 0;

        qtdMagiasAlocadas = 2;
        magias = new Magia[qtdMagiasAlocadas];
        magias[0] = this.GetComponent<RajadaDeAzeitonas>();
        magias[1] = this.GetComponent<DiscoDeCalabresa>();
        posicaoMagiaSelecionada = 0;
        magiaSelecionada = magias[posicaoMagiaSelecionada];
		isComecouConjuracao = false;
		demoraConjuracao = 0.3f;
		tempoPassadoInicioConjuracao = 0;
    }

    //Update is called once per frame
    void Update()
    {
		if (!this.isAtordoado) {
			regenerarMana ();
			carregarMagias ();

			if (this.IsControlavel) {
				obterInput ();
			}

			if (isComecouConjuracao) {
				tempoPassadoInicioConjuracao += Time.deltaTime;

				if (tempoPassadoInicioConjuracao >= demoraConjuracao) {
					lancarMagia ();
				}
			}
		} else {
			isComecouConjuracao = false;
			tempoPassadoInicioConjuracao = 0;
		}
    }

    #region getters e setters
    public bool IsControlavel
    {
        get { return isControlavel; }
        set { isControlavel = value; }
    }

    public int Chances
    {
        get { return chances; }
        set { chances = value; }
	}

    public int ManaTotalOriginal
    {
        get { return manaTotalOriginal; }
        set { manaTotalOriginal = value; }
    }

    public int ManaTotal
    {
        get { return manaTotal; }
        set { manaTotal = value; }
    }

    public int ManaAtual
    {
        get { return manaAtual; }
        set { manaAtual = value; }
    }

    public int TaxaRegeneracaoMana
    {
        get { return taxaRegeneracaoMana; }
        set { taxaRegeneracaoMana = value; }
    }

    public float TempoRegeneracaoMana
    {
        get { return tempoRegeneracaoMana; }
        set { tempoRegeneracaoMana = value; }
    }

    public int QtdMagiasAlocadas
    {
        get { return qtdMagiasAlocadas; }
        set { qtdMagiasAlocadas = value; }
    }

    public Magia[] Magias
    {
        get { return magias; }
        set { magias = value; }
    }

    public Magia MagiaSelecionada
    {
        get { return magiaSelecionada; }
        set { magiaSelecionada = value; }
    }
    #endregion

    #region acoes automaticas
    //restaura pontos de mana gastos
    public void regenerarMana()
    {
        if (tempoPassadoRegeneracao < tempoRegeneracaoMana && manaAtual < manaTotal)
        {
            tempoPassadoRegeneracao += Time.deltaTime;
        }
        else
        {
            alterarMana(taxaRegeneracaoMana);
            tempoPassadoRegeneracao = 0;
        }
    }

    //recarrega magias para que possam ser reutilizadas
    public void carregarMagias()
    {
        foreach (Magia magia in magias)
        {
            if (magia.TempoPassado < magia.Cooldown)
            {
                magia.TempoPassado += Time.deltaTime;
            }
        }
    }
    #endregion

    #region obtencao de input
	//obtem input do controle do jogador
    public void obterInput()
    {
        if (!this.IsComecouAtaque)
        {
           	this.MovimentoX = InputControle.getInstance().MovePad.x;
           	this.pular(InputControle.getInstance().BtnPular);
			tentarConjurar();

			if (this.IsNoChao) 
			{
				this.comecarAtaque(InputControle.getInstance().BtnAtacar);
			}        
        }

		alterarMagia();
    }

    //seleciona magia para ser utilizada
    public void alterarMagia()
    {
        if (InputControle.getInstance().BtnSelectPrev)
        {
            posicaoMagiaSelecionada--;

            if (posicaoMagiaSelecionada < 0)
            {
                posicaoMagiaSelecionada = (qtdMagiasAlocadas - 1);
            }
        }
        else if (InputControle.getInstance().BtnSelectNext)
        {
            posicaoMagiaSelecionada++;

            if (posicaoMagiaSelecionada > (qtdMagiasAlocadas - 1))
            {
                posicaoMagiaSelecionada = 0;
            }
        }

        magiaSelecionada = magias[posicaoMagiaSelecionada];
    }

	//tenta usar a magia
    public void tentarConjurar()
    {
        if (InputControle.getInstance().BtnConjurar)
        {
            if ((manaAtual >= magiaSelecionada.CustoMana) && (magiaSelecionada.TempoPassado >= magiaSelecionada.Cooldown))
            {
				animadorAtor.SetTrigger("conjurar");
				audio.PlayOneShot(clip, 1f); //audio baixo
				isComecouConjuracao = true; 
            }
        }
    }

	public void lancarMagia()
	{
		isComecouConjuracao = false;
		tempoPassadoInicioConjuracao = 0;
		alterarMana(-magiaSelecionada.CustoMana);
		magiaSelecionada.TempoPassado = 0;
		magiaSelecionada.conjurar();  
	}
    #endregion

    #region alteracao de status
	//altera a quantidade de chances do jogador
    public void alterarChances(int valor)
    {
        chances += valor;
    }

	//aumenta ou diminui os pontos de mana atual
    public void alterarMana(int valor)
    { 
        int resultadoFinal = manaAtual + valor;

        if (resultadoFinal > manaTotal)
        {
            manaAtual = manaTotal;
        }
        else if (resultadoFinal < 0)
        {
            manaAtual = 0;
        }
        else
        {
            manaAtual += valor;
        }
    }

	//mata o jogador
    public override void morrer()
    {
		this.animadorAtor.SetBool ("morrer", true);
        alterarChances(-1);

        if (chances >= 0)
        {
			respawnar (); 
        }
    }

	public void respawnar (){
		this.animadorAtor.SetBool ("morrer", false);
		this.transform.position = this.PosicaoSpawn;
		this.VidaAtual = this.VidaTotal;
		this.ManaAtual = this.ManaTotal;
		GameManager.getInstance().continuarJogo();
	}
    #endregion
}
