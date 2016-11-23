﻿using UnityEngine;
using System.Collections;

public class Porta : Objeto
{
    #region atributos
    bool isProntaParaAbrir;
	public AudioClip Door;
	public AudioSource source;
	#endregion

    #region getters e setters
    public bool IsProntaParaAbrir
    {
        get { return isProntaParaAbrir; }
        set { isProntaParaAbrir = value; }
    }
    #endregion

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && isProntaParaAbrir)
        {
			source.PlayOneShot (Door, 2f);
            this.AnimadorObjeto.SetTrigger("abrir");
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}