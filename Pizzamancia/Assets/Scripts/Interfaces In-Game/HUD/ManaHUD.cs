using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManaHUD : MonoBehaviour {
	public static ManaHUD ManaHUDInst;
	Jogador jogador;
	Text manaHUD;
	Slider sliderMana;

	// Use this for initialization
	void Start () {
		ManaHUDInst = this;	
		jogador = GameObject.FindGameObjectWithTag ("Player").GetComponent<Jogador> ();
		manaHUD = GameObject.Find ("Mana HUD").GetComponent<Text> ();
		sliderMana = GameObject.Find ("Slider Mana").GetComponent<Slider> ();

		sliderMana.minValue = 0;
		sliderMana.maxValue = jogador.ManaTotal;
	}
	
	// Update is called once per frame
	void Update () {
		manaHUD.text = "Mana: " + jogador.ManaAtual + "/" + jogador.ManaTotal;
		sliderMana.value = jogador.ManaAtual;
	}

	public static ManaHUD getInstance () {
		return ManaHUDInst;
	}
}
