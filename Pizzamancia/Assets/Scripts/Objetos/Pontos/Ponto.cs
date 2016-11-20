using UnityEngine;
using System.Collections;

public class Ponto : Objeto
{
    #region atributos
    public int valor;

    //audio
    public AudioClip somPego;
    public AudioSource source;
    #endregion

    #region getters e setters
    public int Valor
    {
        get { return valor; }
        set { valor = value; }
    }
    #endregion

    #region eventos
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            source.PlayOneShot(somPego, 1f);
            GameManager.getInstance().alterarPontos(valor);

            Destroy(gameObject);
        }
    }
    #endregion
}
