using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChancesHUD : MonoBehaviour {
	#region atributos
	public static ChancesHUD chancesHUDInst;
	Jogador jogador;
	GameObject chancesHUD;
	#endregion

	// Use this for initialization
	void Start () {
		chancesHUDInst = this;
		jogador = GameObject.FindGameObjectWithTag ("Player").GetComponent<Jogador>();
		chancesHUD = GameObject.Find ("Chances HUD");
	}

	// Update is called once per frame
	void Update () {
		chancesHUD.GetComponent<Text> ().text = jogador.Chances.ToString ();
	}

	public static ChancesHUD getInstance () {
		return chancesHUDInst;
	}
}

