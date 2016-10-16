using UnityEngine;
using System.Collections;

public class HeadboxJogador : MonoBehaviour
{
    public Ator atorCorrespondente;

    public void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag.ToString() == "Inimigo")
        {
            //atorCorrespondente.alterarVida(-1);
        }
    }
}
