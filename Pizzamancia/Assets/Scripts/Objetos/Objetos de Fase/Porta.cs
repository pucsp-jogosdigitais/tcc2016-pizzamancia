using UnityEngine;
using System.Collections;

public class Porta : Objeto {
	public void abrir () {
		//this.AnimadorObjeto.SetTrigger ("abrir");
		this.GetComponent<BoxCollider2D> ().enabled = false;
	}
}
