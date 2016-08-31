using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChancesHUD : MonoBehaviour {
	public static ChancesHUD chancesHUDInst;
	GameObject jogador;
	GameObject chancesHUD;

	// Use this for initialization
	void Start () {
		chancesHUDInst = this;
		jogador = GameObject.FindGameObjectWithTag ("Player");
		chancesHUD = GameObject.Find ("Chances HUD");
	}

	// Update is called once per frame
	void Update () {
		chancesHUD.GetComponent<Text> ().text = jogador.GetComponent<Jogador> ().Chances.ToString ();
	}

	public static ChancesHUD getInstance () {
		return chancesHUDInst;
	}
}

