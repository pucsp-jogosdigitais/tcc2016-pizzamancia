using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManaHUD : MonoBehaviour {
	public static ManaHUD ManaHUDInst;
	GameObject jogador;
	GameObject manaHUD;

	// Use this for initialization
	void Start () {
		ManaHUDInst = this;	
		jogador = GameObject.FindGameObjectWithTag ("Player");
		manaHUD = GameObject.Find ("Mana HUD");
	}
	
	// Update is called once per frame
	void Update () {
		manaHUD.GetComponent<Text> ().text = 
			"Mana: " + jogador.GetComponent<Jogador> ().ManaAtual + "/" + jogador.GetComponent<Jogador> ().ManaTotal;
	}

	public static ManaHUD getInstance () {
		return ManaHUDInst;
	}
}
