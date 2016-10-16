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
    public int Dano
    {
        get { return dano; }
        set { dano = value; }
    }

	public bool IsDestruirToque 
	{
		get { return isDestruirToque; }
		set { isDestruirToque = value; }
	}
    #endregion

    #region evento
    public void OnTriggerEnter2D(Collider2D colisor)
    {
        switch (colisor.gameObject.tag.ToString())
        {
            default:
                break;
            case "Player":
                Jogador jogador = colisor.gameObject.GetComponent<Jogador>();

                jogador.alterarVida(-this.Dano);

				if (isDestruirToque) {
					Destroy (gameObject);
				}
                break;
            case "Inimigo":
                Inimigo inimigo = colisor.gameObject.GetComponent<Inimigo>();

                inimigo.alterarVida(-this.Dano);

				if (isDestruirToque) {
					Destroy (gameObject);
				}
                break;
        }
    }
    #endregion
}
