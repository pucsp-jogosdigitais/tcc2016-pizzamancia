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
                        Vector2 direcaoRecuo = new Vector2();

                        if (this.GetComponentInParent<Jogador>().transform.position.x < inimigo.transform.position.x)
                        {
                            direcaoRecuo = Vector2.up + Vector2.right;
                        }
                        else if (this.GetComponentInParent<Jogador>().transform.position.x > inimigo.transform.position.x)
                        {
                            direcaoRecuo = Vector2.up + Vector2.left;
                        }

                        inimigo.alterarVida(-this.Dano);
                        //inimigo.
                        inimigo.RdbAtor.AddForce(direcaoRecuo * this.ForcaRecuo, ForceMode2D.Impulse);
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
