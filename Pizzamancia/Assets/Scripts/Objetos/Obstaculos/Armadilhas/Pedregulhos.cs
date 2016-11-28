using UnityEngine;
using System.Collections;

public class Pedregulhos : Armadilha {
	
	void Start () {
        this.TempoVida = 0;
        this.Velocidade = 0;

        this.VidaTotal = 0;
        this.VidaAtual = this.VidaTotal;

        this.Dano = 5;
		this.IsDestruirToque = true;
	}
}
