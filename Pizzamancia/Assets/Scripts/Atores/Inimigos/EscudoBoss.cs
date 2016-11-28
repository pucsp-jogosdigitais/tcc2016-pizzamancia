using UnityEngine;
using System.Collections;

public class EscudoBoss : MonoBehaviour 
{
	#region atributos
	public int dano;
	public float forcaRecuo;

	public GameObject brilho;

	public SpriteRenderer spriteEscudo;
	public SpriteRenderer spriteBrilho;
	public Collider2D colliderEscudo;
	#endregion

	void Start()
	{
		dano = 5;
		forcaRecuo = 2f;

		spriteEscudo = this.GetComponent<SpriteRenderer> ();
		spriteBrilho = brilho.GetComponent<SpriteRenderer> ();
		colliderEscudo = this.GetComponent<Collider2D> ();
	}

	#region eventos
	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag.ToString () == "Player") 
		{
			Jogador jogador = colisor.GetComponent<Jogador> ();
			Vector2 direcaoTras = jogador.transform.right;

			jogador.alterarVida(-dano);

			if (this.transform.position.x >= jogador.transform.position.x)
			{
				jogador.RdbAtor.AddForce((Vector2.up - direcaoTras) * forcaRecuo, ForceMode2D.Impulse);
			}
			else if ((this.transform.position.x < jogador.transform.position.x))
			{
				jogador.RdbAtor.AddForce((Vector2.up + direcaoTras) * forcaRecuo, ForceMode2D.Impulse);
			}
		}
	}
	#endregion

	#region acoes
	public void prepararAtivacao()
	{
		spriteEscudo.enabled = true;
	}

	public void ativar()
	{
		spriteBrilho.enabled = true;
		colliderEscudo.enabled = true;;
	}

	public void desativar()
	{
		spriteEscudo.enabled = false;
		spriteBrilho.enabled = false;
		colliderEscudo.enabled = false;
	}
	#endregion
}
