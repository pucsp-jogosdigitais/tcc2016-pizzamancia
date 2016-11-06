using UnityEngine;
using System.Collections;

public class RecuperacaoMana : PowerUp
{

    // Use this for initialization
    void Start()
    {
        this.TempoVida = 0;
        this.Velocidade = 0;
    }

    #region evento
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
			Jogador jogador = collider.gameObject.GetComponent<Jogador>();

            if (jogador.ManaAtual < jogador.ManaTotal)
            {
                jogador.alterarMana(10);

                Destroy(gameObject);
            }
        }
    }
    #endregion
}
