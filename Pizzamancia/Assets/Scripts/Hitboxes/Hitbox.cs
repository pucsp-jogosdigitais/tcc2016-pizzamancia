using UnityEngine;
using System.Collections;

public class Hitbox : MonoBehaviour
{
    #region atributos
    public GameObject objetoAtingido;

    public int dano;
    public float forcaRecuo;
    #endregion

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    #region getters e setters
    public GameObject ObjetoAtingido
    {
        get { return objetoAtingido; }
        set { objetoAtingido = value; }
    }

    public int Dano
    {
        get { return dano; }
        set { dano = value; }
    }

    public float ForcaRecuo
    {
        get { return forcaRecuo; }
        set { forcaRecuo = value; }
    }
    #endregion

    #region eventos
    public void OnTriggerEnter2D(Collider2D colisor)
    {
        if ((colisor.gameObject.tag.ToString() == "Player") ||
            (colisor.gameObject.tag.ToString() == "Inimigo") ||
            (colisor.gameObject.tag.ToString() == "Obstaculo"))
        {
            objetoAtingido = colisor.gameObject;
        }
        else
        {
            objetoAtingido = null;
        }
    }

    public void OnTriggerExit2D(Collider2D colisor)
    {
        objetoAtingido = null;
    }
    #endregion

    public virtual void atingir()
    {
    }
}
