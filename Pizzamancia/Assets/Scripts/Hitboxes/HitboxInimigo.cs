using UnityEngine;
using System.Collections;

public class HitboxInimigo : Hitbox
{
    public override void atingir()
    {
        foreach (GameObject objetoAtingido in this.ObjetosAtingidos)
        {
            if (objetoAtingido != null)
            {
                switch (objetoAtingido.gameObject.tag.ToString())
                {
                    default:
                        break;
                    case "Player":
                        Jogador jogador = objetoAtingido.GetComponent<Jogador>();

                        jogador.alterarVida(-this.Dano);
                        break;
                    case "Obstaculo":
                        Obstaculo obstaculo = objetoAtingido.GetComponent<Obstaculo>();

                        if (obstaculo.IsDestrutivel)
                        {
                            obstaculo.alterarVida(-this.Dano);
                        }
                        break;
                }
            }
        }
    }
}
