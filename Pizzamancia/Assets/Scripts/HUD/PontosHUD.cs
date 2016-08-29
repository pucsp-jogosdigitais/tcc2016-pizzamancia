using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PontosHUD : MonoBehaviour {
	public static PontosHUD pontosHUDInst;
	GameObject jogador;
	GameObject pontosHUD;

	// Use this for initialization
	void Start () {
		pontosHUDInst = this;
		jogador = GameObject.Find ("Jogador");
		pontosHUD = GameObject.Find ("Pontos HUD");
	}

	// Update is called once per frame
	void Update () {
		pontosHUD.GetComponent<Text> ().text = jogador.GetComponent<Jogador> ().PontosLevel.ToString ("0000");
	}

	public static PontosHUD getInstance () {
		return pontosHUDInst;
	}
}
