using UnityEngine;
using System.Collections;

public class RecuperacaoMana : PowerUp
{
    public AudioSource source;

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

            if (jogador.ManaAtual < jogador.ManaTotal)
            {
                source.PlayOneShot(this.SomPego, 1f);
                jogador.alterarMana(10);

                Destroy(gameObject);
            }
        }
    }
    #endregion
}
