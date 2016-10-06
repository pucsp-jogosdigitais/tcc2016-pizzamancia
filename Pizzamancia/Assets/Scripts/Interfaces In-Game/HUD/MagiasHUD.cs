using UnityEngine;
using System.Collections;

public class MagiasHUD : MonoBehaviour {
	public static MagiasHUD magiasHUDInst;
	Jogador jogador;
	public GameObject[] slotsMagias;

	// Use this for initialization
	void Start () {
		magiasHUDInst = this;	
		jogador = GameObject.FindGameObjectWithTag ("Player").GetComponent<Jogador> ();
		slotsMagias = new GameObject[8];

		for (int slot = 0; slot < jogador.SlotsMagia; slot++) {
			int posicaoMagia = slot + 1;
			string str = "Magia " + posicaoMagia.ToString();

			slotsMagias[slot] = GameObject.Find (str);
			//magias.[magia].GetComponent<> ();
		}
	}

	// Update is called once per frame
	/*void Update () {
		for (int slot = 0; slot <= jogador.SlotsMagia; slot++) {
			Magia magia = null;//jogador.Magias.TryGetValue (slot,out Magia a);

			if (jogador.ManaAtual < magia.CustoMana) {
				slotsMagias[slot].GetComponentInChildren<Image> ();
			} else {
			}

			if (magia.TempoPassado < magia.Cooldown) {
			} else {
			}
		}
	}*/

	public static MagiasHUD getInstance () {
		return magiasHUDInst;
	}
}
