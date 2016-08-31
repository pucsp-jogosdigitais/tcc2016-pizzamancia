using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class Jogador : Ator
{
    #region atributos
	public bool isControlavel;

    //vida
    public int chances; //quantas chances o jogador tem no momento

    //mana
    public int manaTotal; //quantos pontos de mana o jogador tem no total
    public int manaAtual; //quantos pontos de mana o jogador tem no momento
    public int taxaRegeneracaoMana; //quantos pontos de mana sao regenerados apos um certo intervalo
    public float tempoRegeneracaoMana; //intervalo que demora para regenerar pontos de mana
    float tempoPassadoRegeneracao; //quanto tempo passou depois do ultimo intervalo de regeneracao de mana

    //magias
    public int slotsMagia; //quantas magias o jogador pode escolher para um level
    public Dictionary<int, Magia> magias; //magias escolhidas para o level
    public int posicaoMagiaSelecionada; //posicao da magia no dictionary de magias
    public Magia magiaSelecionada; //magia selecionada no momento pelo jogador
    #endregion

    // Use this for initialization
    void Start()
    {
		isControlavel = true;

        this.Velocidade = 2;
        this.ForcaPulo = 4;

		this.HitboxAtor.Dano = 2;
		this.DemoraAtaque = 0.25f;
		this.DuracaoAtaque = 0.25f;

        chances = 3;

        this.VidaTotal = 50;
        this.VidaAtual = vidaTotal;

        manaTotal = 100;
        manaAtual = manaTotal;
        taxaRegeneracaoMana = 10;
        tempoRegeneracaoMana = 1;
        tempoPassadoRegeneracao = 0;

        slotsMagia = 2;
        magias = new Dictionary<int, Magia>();
        magias.Add(0, this.GetComponent<RajadaDeAzeitonas>());
        magias.Add(1, this.GetComponent<DiscoDeCalabresa>());

        //foreach (KeyValuePair<int, Magia> m in magias)
        //{
        //    m.Value.Conjurador = this;
        //}

        posicaoMagiaSelecionada = 0;
        magiaSelecionada = magias[posicaoMagiaSelecionada];
    }

    // Update is called once per frame
    void Update()
    {
        regenerarMana();
        carregarMagias();

		if (isControlavel) {
			obterInput ();
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

    public int SlotsMagia
    {
        get { return slotsMagia; }
        set { slotsMagia = value; }
    }

    public Dictionary<int, Magia> Magias
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
        foreach (KeyValuePair<int, Magia> m in magias)
        {
            if (m.Value.TempoPassado < m.Value.Cooldown)
            {
                m.Value.TempoPassado += Time.deltaTime;
            }
        }
    }
    #endregion

    #region obtencao de input
	//obtem input do controle do jogador
    public void obterInput()
    { 
        this.MovimentoX = InputControle.getInstance().MovePad.x;
        this.pular(InputControle.getInstance().BtnPular);
		this.comecarAtaque (InputControle.getInstance().BtnAtacar);

        alterarMagia();
        tentarConjurar();
    }

	//seleciona magia para ser utilizada
    public void alterarMagia()
    { 
        if (InputControle.getInstance().BtnSelectPrev)
        {
            posicaoMagiaSelecionada--;

            if (posicaoMagiaSelecionada < 0)
            {
                posicaoMagiaSelecionada = (slotsMagia - 1);
            }
        }
        else if (InputControle.getInstance().BtnSelectNext)
        {
            posicaoMagiaSelecionada++;

            if (posicaoMagiaSelecionada > (slotsMagia - 1))
            {
                posicaoMagiaSelecionada = 0;
            }
        }

        magiaSelecionada = magias[posicaoMagiaSelecionada];
    }
		
    public void tentarConjurar()
	{ //tenta usar a magia
        if (InputControle.getInstance().BtnConjurar)
        {
            if ((manaAtual >= magiaSelecionada.CustoMana) && (magiaSelecionada.tempoPassado >= magiaSelecionada.Cooldown))
            {
                alterarMana(-magiaSelecionada.CustoMana);
                magiaSelecionada.TempoPassado = 0;
                magiaSelecionada.conjurar();
            }
        }
    }
    #endregion

    #region alteracao de status
	public void alterarChances (int valor) {
		chances += valor;
	}

    public void alterarMana(int valor)
	{ //aumenta ou diminui os pontos de mana atual
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

	public override void morrer () {
		alterarChances (-1);

		if (chances >= 0) {
			this.transform.position = this.PosicaoSpawn;
		}
	}
    #endregion
}
