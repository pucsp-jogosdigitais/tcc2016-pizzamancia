using UnityEngine;
using System.Collections;

public class Armadilha : Obstaculo
{
	#region atributos

	//dano
	public int dano;

	//colisao
	public bool isDestruirToque;

	#endregion

	#region getters e setters

	public int Dano {
		get { return dano; }
		set { dano = value; }
	}

	public bool IsDestruirToque {
		get { return isDestruirToque; }
		set { isDestruirToque = value; }
	}

	#endregion

	#region evento

	public void OnTriggerEnter2D (Collider2D colisor)
	{
		if (colisor.gameObject.layer == 9) 
		{
			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), colisor);
		} 
		else 
		{
			switch (colisor.gameObject.tag.ToString ()) {
			default:
				break;
			case "Hitbox":
				Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), colisor);

				return;
			case "Headbox":
				Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), colisor);

				return;
			case "Player":
				Jogador jogador = colisor.gameObject.GetComponent<Jogador> ();

				jogador.alterarVida (-dano);

				break;
			case "Inimigo":
				Inimigo inimigo = colisor.gameObject.GetComponent<Inimigo> ();

				inimigo.alterarVida (-dano);

				break;
			case "Obstaculo":
				Obstaculo obstaculo = colisor.gameObject.GetComponent<Obstaculo> ();

				obstaculo.alterarVida (-dano);

				break;
			}

			if (isDestruirToque) {
				Destroy (gameObject);
			}
		}
	}

	#endregion
}
