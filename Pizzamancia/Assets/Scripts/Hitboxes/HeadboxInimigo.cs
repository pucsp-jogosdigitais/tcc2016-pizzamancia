using UnityEngine;
using System.Collections;

public class HeadboxInimigo : Headbox {
	public void OnTriggerStay2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag.ToString() == "Player" ||
			colisor.gameObject.tag.ToString() == "Inimigo")
		{
			Ator Esmagador = colisor.GetComponent<Ator> ();
			float forcaRecuo = 2f;

			AtorRespectivo.alterarVida (-1);

			if (Random.Range(0, 2) == 0) 
			{
				Esmagador.RdbAtor.AddForce ((Vector2.up + Vector2.left) * forcaRecuo, ForceMode2D.Impulse);
			} 
			else
			{
				Esmagador.RdbAtor.AddForce ((Vector2.up + Vector2.right) * forcaRecuo, ForceMode2D.Impulse);
			}
		}
	}
}
