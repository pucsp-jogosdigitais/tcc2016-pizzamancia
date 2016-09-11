﻿using UnityEngine;
using System.Collections;

public class HitboxJogador : Hitbox
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void atingir()
    {
        if (this.ObjetoAtingido != null)
        {
            switch (this.ObjetoAtingido.gameObject.tag.ToString())
            {
                default:
                    break;
                case "Inimigo":
                    Inimigo inimigo = this.ObjetoAtingido.GetComponent<Inimigo>();

                    inimigo.alterarVida(-this.Dano);
                    break;
                case "Obstaculo":
                    Obstaculo obstaculo = this.ObjetoAtingido.GetComponent<Obstaculo>();

                    if (obstaculo.VidaTotal != 0)
                    {
                        obstaculo.alterarVida(-this.Dano);
                    }
                    break;
            }
        }
    }
}
