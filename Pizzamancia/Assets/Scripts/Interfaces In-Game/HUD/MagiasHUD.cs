using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MagiasHUD : MonoBehaviour
{
    #region atributos
    public static MagiasHUD magiasHUDInst;
    Jogador jogador;
    public Text magiasHUD;
	public GameObject iconeSlotSelecionado;
    public SlotMagia[] slotsMagia;
    #endregion

    //Use this for initialization
    void Start()
    {
        magiasHUDInst = this;
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
        magiasHUD = GameObject.Find("Magias HUD").GetComponent<Text>();
		iconeSlotSelecionado = GameObject.Find ("Icone Slot Selecionado");
        slotsMagia = new SlotMagia[jogador.QtdMagiasAlocadas];

        for (int slot = 0; slot < jogador.QtdMagiasAlocadas; slot++)
        {
            int posicaoMagia = slot + 1;
            string stringSlotMagia = "Slot Magia " + posicaoMagia.ToString();

            slotsMagia[slot] = GameObject.Find(stringSlotMagia).GetComponent<SlotMagia>();
            slotsMagia[slot].MagiaContida = jogador.Magias[slot];
        }
    }

    //Update is called once per frame
    void Update()
    {
        magiasHUD.text = jogador.MagiaSelecionada.Nome;

        for (int slot = 0; slot < jogador.QtdMagiasAlocadas; slot++)
        {
            Magia magia = jogador.Magias[slot];
			float posicaoIconeY = 175 + (slot * -50);
            float segundosRestantesCooldown = magia.Cooldown - magia.TempoPassado;

			if (jogador.MagiaSelecionada.Equals(magia)) 
			{
				iconeSlotSelecionado.transform.localPosition = new Vector2 (0, posicaoIconeY);
			}

            if (jogador.ManaAtual < magia.CustoMana)
            {
                slotsMagia[slot].FiltroSemMana.enabled = true;
            }
            else
            {
                slotsMagia[slot].FiltroSemMana.enabled = false;
            }

            if (magia.TempoPassado < magia.Cooldown)
            {
                slotsMagia[slot].CooldownTimer.text = segundosRestantesCooldown.ToString("0");
            }
            else
            {
                slotsMagia[slot].CooldownTimer.text = "";
            }
        }
    }

    public static MagiasHUD getInstance()
    {
        return magiasHUDInst;
    }
}
