using UnityEngine;
using System.Collections;

public class HitboxJogador : Hitbox
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
                    case "Inimigo":
                        Inimigo inimigo = objetoAtingido.GetComponent<Inimigo>();

                        inimigo.alterarVida(-this.Dano);
                        break;
                    case "Obstaculo":
                        Obstaculo obstaculo = objetoAtingido.GetComponent<Obstaculo>();

                        if (obstaculo.VidaTotal != 0)
                        {
                            obstaculo.alterarVida(-this.Dano);
                        }
                        break;
                }
            }
        }
    }
}
