using UnityEngine;
using System.Collections;

public class PlatataformaFundo : MonoBehaviour {
	public Plataform plataformaRespectiva;

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag.ToString() == "Headbox") 
		{
			plataformaRespectiva.IsFundoTocado = true;
		}
	}
}
