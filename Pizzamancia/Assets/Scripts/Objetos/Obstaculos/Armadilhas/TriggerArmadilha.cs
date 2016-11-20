using UnityEngine;
using System.Collections;

public class TriggerArmadilha : MonoBehaviour {
	public Armadilha[] armadilhas;

	public void OnTriggerEnter2D (Collider2D colisor)
	{
		if (colisor.gameObject.tag.ToString() == "Player" ||
			colisor.gameObject.tag.ToString() == "Inimigo") 
		{
			foreach (Armadilha armadilha in armadilhas) 
			{
				armadilha.RdbObjeto.isKinematic = false;
			}
			Destroy (gameObject);
		} 
	}
}
