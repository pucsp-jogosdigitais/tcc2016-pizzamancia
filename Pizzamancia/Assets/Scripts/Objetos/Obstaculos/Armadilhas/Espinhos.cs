using UnityEngine;
using System.Collections;

public class Espinhos : Armadilha
{
    // Use this for initialization
    void Start()
    {
        this.TempoVida = 0;
        this.Velocidade = 0;

        this.VidaTotal = 0;
        this.VidaAtual = this.VidaTotal;

        this.Dano = 100000;
    }
}
