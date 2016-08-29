using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	//
	public static GameManager gameManagerInst;

	// Use this for initialization
	void Start () {
		gameManagerInst = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	//obtem
	public static GameManager getInstance () {
		return gameManagerInst;
	}

	//navegacao geral
	//carrega interfaces e levels
	public void carregarTela (string tela) {
		Application.LoadLevel (tela);
	}

	//recarrega level atual
	public void recarregarLevel () {
		Application.LoadLevel (Application.loadedLevel);
	}

	//sai do jogo
	public void sairJogo () {
		Application.Quit ();
	}

	//parada e continuacao do jogo
	//para o jogo
	public void pararJogo () {
		Time.timeScale = 0;
	}

	//continua o jogo
	public void continuarJogo () {
		Time.timeScale = 1;
	}

	//inicio, salva e carregamento de jogo
	//inicia novo jogo
	public void iniciarNovoJogo () {
	}
		
	//salva o jogo
	public void salvarJogo () {
	}

	//carrega jogo salvo
	public void carregarJogoSalvo () {
	}
		
	//configuracoes de jogo
	//configuracoes de video
	//configuracoes de audio

	//preparacao e inicio de level

	//encerramento de level
}
