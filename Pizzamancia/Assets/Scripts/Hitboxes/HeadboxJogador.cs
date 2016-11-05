using UnityEngine;
using System.Collections;

public class HeadboxJogador : Headbox {
	public void OnTriggerStay2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag.ToString() == "Inimigo")
		{
			Inimigo inimigo = colisor.GetComponent<Inimigo> ();
			float forcaRecuo = 5f;

			AtorRespectivo.alterarVida (-1);

			if (Random.Range(0, 2) == 0) 
			{
				inimigo.RdbAtor.AddForce ((Vector2.up + Vector2.left) * forcaRecuo, ForceMode2D.Impulse);
			} 
			else
			{
				inimigo.RdbAtor.AddForce ((Vector2.up + Vector2.right) * forcaRecuo, ForceMode2D.Impulse);
			}
		}
	}
}
