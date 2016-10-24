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
            var player = collider.gameObject.GetComponent<Jogador>();

            if (player.VidaAtual < player.VidaTotal)
            {
                player.alterarVida(10);

                Destroy(gameObject);
            }
        }
    }
    #endregion
}
