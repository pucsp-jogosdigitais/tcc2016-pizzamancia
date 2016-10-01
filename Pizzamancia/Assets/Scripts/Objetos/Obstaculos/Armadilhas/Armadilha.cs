using UnityEngine;
using System.Collections;

public class Armadilha : Obstaculo
{
    #region atributos
    //dano
    public int dano;
    #endregion

    #region getters e setters
    public int Dano
    {
        get { return dano; }
        set { dano = value; }
    }
    #endregion

    #region eventos
    public void OnTriggerEnter2D(Collider2D colisor)
    {
        switch (colisor.gameObject.tag.ToString())
        {
            default:
                break;
            case "Player":
                Jogador jogador = colisor.gameObject.GetComponent<Jogador>();

                jogador.alterarVida(-this.Dano);
                break;
            case "Inimigo":
                Inimigo inimigo = colisor.gameObject.GetComponent<Inimigo>();

                inimigo.alterarVida(-this.Dano);
                break;
        }
    }

    public void OnTriggerExit2D(Collider2D colisor)
    {
    }
    #endregion
}
