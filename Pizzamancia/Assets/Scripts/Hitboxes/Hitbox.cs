using UnityEngine;
using System.Collections;

public class Hitbox : MonoBehaviour {
	#region atributos
	public int dano;
	public float forcaRecuo;
	#endregion

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
	}

	#region getters e setters
	public int Dano 
	{
		get { return dano; }
		set { dano = value; }
	}

	public float ForcaRecuo 
	{
		get { return forcaRecuo; }
		set { forcaRecuo = value; }
	}
	#endregion
}
