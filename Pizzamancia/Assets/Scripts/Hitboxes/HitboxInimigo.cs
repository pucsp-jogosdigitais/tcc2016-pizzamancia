using UnityEngine;
using System.Collections;

public class HitboxInimigo : Hitbox
{
	public override void atingir ()
	{
	//audio.PlayOneShot("ataque", 1f);
	
		foreach (GameObject objetoAtingido in this.ObjetosAtingidos) {
			if (objetoAtingido != null) {
			//this.AtorRespectivo.AudioSourceAtor.PlayOneShot("ataque inimigo", 1f);
			
				switch (objetoAtingido.gameObject.tag.ToString ()) {
				default:
					break;
				case "Player":
					Jogador jogador = objetoAtingido.GetComponent<Jogador> ();
					Vector2 direcaoTras = jogador.transform.right;

					jogador.alterarVida (-this.Dano);

					if (atorRespectivo.transform.position.x > jogador.transform.position.x) {
						jogador.RdbAtor.AddForce ((Vector2.up - direcaoTras) * this.ForcaRecuo, ForceMode2D.Impulse);
					} else if (atorRespectivo.transform.position.x < jogador.transform.position.x) {
						jogador.RdbAtor.AddForce ((Vector2.up + direcaoTras) * this.ForcaRecuo, ForceMode2D.Impulse);
					}

					break;
				case "Obstaculo":
					Obstaculo obstaculo = objetoAtingido.GetComponent<Obstaculo> ();

					if (obstaculo.IsDestrutivel) {
						obstaculo.alterarVida (-this.Dano);
					}

					break;
				}
			}
		}
	}
}
