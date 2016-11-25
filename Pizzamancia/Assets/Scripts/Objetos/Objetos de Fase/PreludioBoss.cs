using UnityEngine;
using System.Collections;

public class PreludioBoss : MonoBehaviour 
{
	public Boss bossRespectivo;

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag.ToString () == "Player") 
		{
			bossRespectivo.comecarLuta ();
		}
	}
}
