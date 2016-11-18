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
                this.AtorRespectivo.AudioSourceAtor.PlayOneShot(this.SomAtaqueAtingido, 5f);

                switch (objetoAtingido.gameObject.tag.ToString())
                {
                    default:
                        break;
                    case "Inimigo":
                        Inimigo inimigo = objetoAtingido.GetComponent<Inimigo>();
                        Vector2 direcaoTras = inimigo.transform.right;

                        inimigo.alterarVida(-this.Dano);

                        if (atorRespectivo.transform.position.x > inimigo.transform.position.x)
                        {
                            inimigo.RdbAtor.AddForce((Vector2.up - direcaoTras) * this.ForcaRecuo, ForceMode2D.Impulse);
                        }
                        else if (atorRespectivo.transform.position.x < inimigo.transform.position.x)
                        {
                            inimigo.RdbAtor.AddForce((Vector2.up + direcaoTras) * this.ForcaRecuo, ForceMode2D.Impulse);
                        }

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
