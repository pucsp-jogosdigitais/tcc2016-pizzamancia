using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VidaHUD : MonoBehaviour {
	public static VidaHUD vidaHUDInst;
	GameObject jogador;
	GameObject vidaHUD;

	// Use this for initialization
	void Start () {
		vidaHUDInst = this;	
		jogador = GameObject.Find ("Jogador");
		vidaHUD = GameObject.Find ("Vida HUD");
	}

	// Update is called once per frame
	void Update () {
		vidaHUD.GetComponent<Text> ().text = 
			"Vida: " + jogador.GetComponent<Jogador> ().VidaAtual + "/" + jogador.GetComponent<Jogador> ().VidaTotal;
	}

	public static VidaHUD getInstance () {
		return vidaHUDInst;
	}
}
