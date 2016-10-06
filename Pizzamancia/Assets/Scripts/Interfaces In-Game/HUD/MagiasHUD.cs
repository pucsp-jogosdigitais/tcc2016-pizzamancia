using UnityEngine;
using System.Collections;

public class MagiasHUD : MonoBehaviour
{
	#region atributos
    public static MagiasHUD magiasHUDInst;
    Jogador jogador;
	public SlotMagia[] slotsMagia;
	#endregion

    // Use this for initialization
    void Start()
    {
        magiasHUDInst = this;
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
		slotsMagia = new SlotMagia[jogador.QtdMagiasAlocadas];

        for (int slot = 0; slot < jogador.QtdMagiasAlocadas; slot++)
        {
            int posicaoMagia = slot + 1;
			string stringSlotMagia = "Magia " + posicaoMagia.ToString();

			slotsMagia[slot] = GameObject.Find(stringSlotMagia).GetComponent<SlotMagia>();
			slotsMagia[slot].MagiaContida = jogador.Magias[slot];
        }
    }

    // Update is called once per frame
    void Update () {
        for (int slot = 0; slot < jogador.QtdMagiasAlocadas; slot++) {
			Magia magia = jogador.Magias[slot];

            if (jogador.ManaAtual < magia.CustoMana) {
                //slotsMagias[slot].GetComponentInChildren<Image> ();
            } else {
            }

            if (magia.TempoPassado < magia.Cooldown) {
            } else {
            }
        }
    }

    public static MagiasHUD getInstance()
    {
        return magiasHUDInst;
    }
}
