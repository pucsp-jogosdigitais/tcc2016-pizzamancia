using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlotMagia : MonoBehaviour {
	public Magia magiaContida;
	public Image iconeMagia;
	public Text cooldownTimer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Magia MagiaContida
	{
		get{ return magiaContida; }
		set{ magiaContida = value; }
	}

	public Image IconeMagia
	{
		get{ return iconeMagia; }
		set{ iconeMagia = value; }
	}

	public Text CooldownTimer 
	{
		get{ return cooldownTimer; }
		set{ cooldownTimer = value; }
	}
}
