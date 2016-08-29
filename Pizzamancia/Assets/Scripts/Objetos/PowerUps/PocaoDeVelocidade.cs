using UnityEngine;
using System.Collections;

public class PocaoDeVelocidade : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            var player = collider.gameObject.GetComponent<Jogador>();

			player.Velocidade *= 3;

            Destroy(gameObject);
		}
	}
}
