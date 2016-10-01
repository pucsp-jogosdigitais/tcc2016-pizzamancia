using UnityEngine;
using System.Collections;

public class Pedregulhos : Armadilha {

	// Use this for initialization
	void Start () {
        this.TempoVida = 0;
        this.Velocidade = 5;

        this.VidaTotal = 0;
        this.VidaAtual = this.VidaTotal;

        this.Dano = 10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
