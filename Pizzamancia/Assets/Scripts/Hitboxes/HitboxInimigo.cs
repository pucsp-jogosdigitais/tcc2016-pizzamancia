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

                        //jogador.RdbAtor.velocity = new Vector2(0, 0);
                        jogador.MovimentoX = 0;

                        jogador.alterarVida(-this.Dano);
                        jogador.RdbAtor.AddForce((Vector2.up + Vector2.right) * this.ForcaRecuo, ForceMode2D.Impulse);
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
