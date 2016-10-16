using UnityEngine;
using System.Collections;

public class HeadboxInimigo : MonoBehaviour
{
    public Ator atorCorrespondente;

    public void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag.ToString() == "Player")
        {
            //Ator jogador = colisor.gameObject.GetComponent<Ator>();

            //jogador.MovimentoX = 0;

            //atorCorrespondente.alterarVida(-1);
            //jogador.RdbAtor.AddForce((Vector2.up + Vector2.right) * 2, ForceMode2D.Impulse);
        }
    }
}
