﻿using UnityEngine;
using System.Collections;

public class Espinhos : Armadilha
{
    void Start()
    {
        this.TempoVida = 0;
        this.Velocidade = 0;

        this.VidaTotal = 0;
        this.VidaAtual = this.VidaTotal;

        this.Dano = 1000;
		this.IsDestruirToque = false;
    }
}
