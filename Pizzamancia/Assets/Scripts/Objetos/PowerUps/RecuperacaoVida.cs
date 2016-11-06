using UnityEngine;
using System.Collections;

public class RecuperacaoVida : PowerUp
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

            if (jogador.VidaAtual < jogador.VidaTotal)
            {
                jogador.alterarVida(10);

                Destroy(gameObject);
            }
        }
    }
    #endregion
}
