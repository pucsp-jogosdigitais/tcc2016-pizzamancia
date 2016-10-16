using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlotMagia : MonoBehaviour
{
	#region atributos
    public Magia magiaContida;
	public Image iconeMagia;
	public Image filtroSemMana;
	public Text cooldownTimer;
	#endregion

	#region getters e setters
    public Magia MagiaContida
    {
        get { return magiaContida; }
        set { magiaContida = value; }
    }
		
	public Image IconeMagia
	{
		get { return iconeMagia; }
		set { iconeMagia = value; }
	}

	public Image FiltroSemMana
    {
        get { return filtroSemMana; }
        set { filtroSemMana = value; }
    }

    public Text CooldownTimer
    {
        get { return cooldownTimer; }
        set { cooldownTimer = value; }
    }
	#endregion
}
