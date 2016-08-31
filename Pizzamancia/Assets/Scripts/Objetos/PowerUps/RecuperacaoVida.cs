using UnityEngine;
using System.Collections;

public class RecuperacaoVida : PowerUp {

	// Use this for initialization
	void Start () {
		this.TempoVida = 0;
		this.Velocidade = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            var player = collider.gameObject.GetComponent<Jogador>();

			player.alterarVida (10);

            Destroy(gameObject);
		}	
	}
}
