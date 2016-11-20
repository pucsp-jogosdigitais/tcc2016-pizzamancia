using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VidaHUD : MonoBehaviour
{
    #region atributos
    public static VidaHUD vidaHUDInst;
    Jogador jogador;
    Text vidaHUD;
    Slider sliderVida;
    #endregion

    // Use this for initialization
    void Start()
    {
        vidaHUDInst = this;
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
        //vidaHUD = GameObject.Find("Vida HUD").GetComponent<Text>();
        sliderVida = GameObject.Find("Slider Vida").GetComponent<Slider>();

        sliderVida.minValue = 0;
        sliderVida.maxValue = jogador.VidaTotal;
    }

    // Update is called once per frame
    void Update()
    {
        //vidaHUD.text = "Vida: " + jogador.VidaAtual + "/" + jogador.VidaTotal;
        sliderVida.value = jogador.VidaAtual;
    }

    public static VidaHUD getInstance()
    {
        return vidaHUDInst;
    }
}
