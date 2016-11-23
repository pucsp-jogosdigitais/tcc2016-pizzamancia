using UnityEngine;
using System.Collections;

public class PlatataformaFundo : MonoBehaviour 
{
	#region atributos
	public PlataformaY plataformaYRespectiva;
	#endregion

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag.ToString() == "Headbox") 
		{
			plataformaYRespectiva.IsFundoTocado = true;
		}
	}
}
