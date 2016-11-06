using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PontosHUD : MonoBehaviour {
	#region atributos
	public static PontosHUD pontosHUDInst;
	GameObject pontosHUD;
	#endregion

	// Use this for initialization
	void Start () {
		pontosHUDInst = this;
		pontosHUD = GameObject.Find ("Pontos HUD");
	}

	// Update is called once per frame
	void Update () {
		pontosHUD.GetComponent<Text> ().text = GameManager.getInstance ().PontosLevel.ToString ("0000");
	}

	public static PontosHUD getInstance () {
		return pontosHUDInst;
	}
}
