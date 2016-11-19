using UnityEngine;
using System.Collections;

public class RecuperacaoVida : PowerUp
{
    public AudioSource source;
    // Use this for initialization
    void Start()
    {
        source = GameObject.Find("Audio ambiente").GetComponent<AudioSource>();
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
				source.PlayOneShot(this.SomPego, 5f);
                jogador.alterarVida(10);

                Destroy(gameObject);
            }
        }
    }
    #endregion
}
