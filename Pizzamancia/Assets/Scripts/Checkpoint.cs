using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	#region atributos
	public bool isAlcancado;
	#endregion

	// Use this for initialization
	void Start () {
		isAlcancado = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region getters e setters
	public bool IsAlcancado
	{
		get { return isAlcancado; }
		set {isAlcancado = value; }
	}
	#endregion

	public void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player" && !isAlcancado)
		{
			var player = collider.gameObject.GetComponent<Jogador>();
			isAlcancado = true;

			player.PosicaoSpawn = this.transform.position;
		}	
	}
}
