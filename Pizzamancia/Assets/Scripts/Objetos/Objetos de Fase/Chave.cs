﻿using UnityEngine;
using System.Collections;

public class Chave : Objeto
{
    #region atributos
    public Porta portaRespectiva;
	public AudioClip pegar;
	public AudioSource source;
    #endregion

    // Use this for initialization
    void Start()
    {
        this.TempoVida = 0;
        this.Velocidade = 0;
    }

    #region getters e setters
    public Porta PortaRespectiva
    {
        get { return portaRespectiva; }
        set { portaRespectiva = value; }
    }
    #endregion

    #region evento
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            portaRespectiva.IsProntaParaAbrir = true;
			source.PlayOneShot (pegar, 1f);
            Destroy(gameObject);
        }
    }
    #endregion
}
