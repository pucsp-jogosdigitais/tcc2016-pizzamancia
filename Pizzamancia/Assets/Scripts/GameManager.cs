using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	#region atributos
	public static GameManager gameManagerInst;

	//pontuacao
	public int pontosLevel;
	public int pontosGlobal;
	#endregion

	// Use this for initialization
	void Start () {
		gameManagerInst = this;

		pontosLevel = 0;
		pontosGlobal = pontosLevel;
	}
	
	// Update is called once per frame
	void Update () {
	}
		
	#region getters e setters
	public static GameManager getInstance () {
		return gameManagerInst;
	}

	public int PontosLevel 
	{
		get { return pontosLevel; }
		set { pontosLevel = value; }
	}

	public int PontosGlobal 
	{
		get { return pontosGlobal; }
		set { pontosGlobal = value; }
	}
	#endregion

	#region navegacao geral
	public void carregarTela (string tela) 
	{ //carrega interfaces e levels
		Application.LoadLevel (tela);
	}
		
	public void recarregarLevel () 
	{ //recarrega level atual
		Application.LoadLevel (Application.loadedLevel);
	}
		
	public void sairJogo () 
	{ //sai do jogo
		Application.Quit ();
	}
	#endregion

	#region parada e continuacao do jogo
	public void pararJogo () 
	{ //para o jogo
		Time.timeScale = 0;
	}
		
	public void continuarJogo () 
	{ //continua o jogo
		Time.timeScale = 1;
	}
	#endregion

	#region inicio, salva e carregamento de jogo
	public void iniciarNovoJogo () 
	{ //inicia novo jogo
	}

	public void salvarJogo () 
	{ //salva o jogo
	}
		
	public void carregarJogoSalvo () 
	{ //carrega jogo salvo
	}
	#endregion
		
	#region configuracoes
	//configuracoes de jogo
	//configuracoes de video
	//configuracoes de audio
	#endregion

	#region comeco e finalizacao de level
	//preparacao e inicio de level

	//encerramento de level
	#endregion

	#region alteracao de status
	public void alterarPontos(int valor)
	{ //aumenta ou diminui os pontos obtidos no level
		int resultadoFinal = pontosLevel + valor;

		if (resultadoFinal < 0)
		{
			pontosLevel = 0;
		}
		else
		{
			pontosLevel += valor;
		}
	}
	#endregion
}
