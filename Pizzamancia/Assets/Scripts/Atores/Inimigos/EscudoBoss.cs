using UnityEngine;
using System.Collections;

public class EscudoBoss : MonoBehaviour {
	public void ativar()
	{
		this.gameObject.SetActive (true);
	}

	public void desativar()
	{
		this.gameObject.SetActive (false);
	}
}
