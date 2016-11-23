using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    #region atributos
    public bool isAlcancado;
	public Animator animadorCheckpoint;
    #endregion

    // Use this for initialization
    void Start()
    {
        isAlcancado = false;
		animadorCheckpoint = this.gameObject.GetComponent<Animator> ();
    }

    #region getters e setters
    public bool IsAlcancado
    {
        get { return isAlcancado; }
        set { isAlcancado = value; }
    }

	public Animator AnimadorCheckpoint
	{
		get{ return animadorCheckpoint; }
		set{ animadorCheckpoint = value; }
	}
    #endregion

    #region eventos
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && !isAlcancado)
        {
            Jogador jogador = collider.gameObject.GetComponent<Jogador>();

            isAlcancado = true;
            jogador.PosicaoSpawn = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
        
			animadorCheckpoint.SetTrigger ("ativado");
		}
    }
    #endregion
}
