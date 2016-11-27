using UnityEngine;
using System.Collections;

public class WaypointBoss : MonoBehaviour {
	public bool isBossChegou;

	public bool IsBossChegou
	{
		get { return isBossChegou; }
		set { isBossChegou = value; }
	}

	void OnTriggerEnter2D (Collider2D colisor)
	{
		if (colisor.gameObject.name == "Malvagius") 
		{
			isBossChegou = true;
		}
	}

	void OnTriggerExit2D (Collider2D colisor)
	{
		if (colisor.gameObject.name == "Malvagius") 
		{
			isBossChegou = false;
		}
	}
}
