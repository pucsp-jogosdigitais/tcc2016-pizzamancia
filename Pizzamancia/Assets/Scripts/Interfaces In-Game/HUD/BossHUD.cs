using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHUD : MonoBehaviour
{
	#region atributos
	public static BossHUD bossHUDInst;
	Boss bossRespectivo;
	Text bossHUD;
	Slider sliderBoss;
	#endregion

	// Use this for initialization
	void Start()
	{
		bossHUDInst = this;
		bossRespectivo = null;
		bossHUD = GameObject.Find("Boss HUD").GetComponent<Text>();
		sliderBoss = GameObject.Find("Slider Boss").GetComponent<Slider>();

		sliderBoss.minValue = 0;

		bossHUDInst.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update()
	{
		if (bossRespectivo != null) 
		{
			bossHUD.text = bossRespectivo.VidaAtual + "/" + bossRespectivo.VidaTotal;
			sliderBoss.value = bossRespectivo.VidaAtual;
		} 
		else 
		{
			bossHUD.text = "";
			sliderBoss.value = 0;
		}
	}

	public static BossHUD getInstance()
	{
		return bossHUDInst;
	}

	public void comecarLuta (Boss boss)
	{
		bossRespectivo = boss;

		sliderBoss.maxValue = bossRespectivo.VidaTotal;

		bossHUDInst.gameObject.SetActive (true);
	}
}
