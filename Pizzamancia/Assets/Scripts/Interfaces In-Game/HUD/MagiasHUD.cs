using UnityEngine;
using System.Collections;

public class MagiasHUD : MonoBehaviour
{
	#region atributos
    public static MagiasHUD magiasHUDInst;
    Jogador jogador;
    public SlotMagia[] slotsMagias;
	#endregion

    // Use this for initialization
    void Start()
    {
        magiasHUDInst = this;
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
		slotsMagias = new SlotMagia[jogador.SlotsMagia];

        for (int slot = 0; slot < jogador.SlotsMagia; slot++)
        {
            int posicaoMagia = slot + 1;
            string strMagia = "Magia " + posicaoMagia.ToString();
			Magia erro = null;

            slotsMagias[slot] = GameObject.Find(strMagia).GetComponent<SlotMagia>();
			slotsMagias[slot].MagiaContida = jogador.Magias[slot];
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

    public static MagiasHUD getInstance()
    {
        return magiasHUDInst;
    }
}
