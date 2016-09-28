using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hitbox : MonoBehaviour
{
    #region atributos
    public List<GameObject> objetosAtingidos;

	public int danoOriginal;
    public int dano;
	public float forcaRecuoOriginal;
    public float forcaRecuo;
    #endregion

    // Use this for initialization
    void Start()
    {
        objetosAtingidos = new List<GameObject>();
    }

    #region getters e setters
    public List<GameObject> ObjetosAtingidos
    {
        get { return objetosAtingidos; }
        set { objetosAtingidos = value; }
    }

	public int DanoOriginal
	{
		get { return danoOriginal; }
		set { danoOriginal = value; }
	}

    public int Dano
    {
        get { return dano; }
        set { dano = value; }
    }

	public float ForcaRecuoOriginal
	{
		get { return forcaRecuoOriginal; }
		set { forcaRecuoOriginal = value; }
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
            if (!objetosAtingidos.Contains(colisor.gameObject))
            {
                objetosAtingidos.Add(colisor.gameObject);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D colisor)
    {
        if (objetosAtingidos.Contains(colisor.gameObject))
        {
            objetosAtingidos.Remove(colisor.gameObject);
        }
    }
    #endregion

    public virtual void atingir()
    {
    }
}
