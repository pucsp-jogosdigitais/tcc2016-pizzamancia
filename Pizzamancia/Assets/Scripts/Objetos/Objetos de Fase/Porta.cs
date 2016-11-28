using UnityEngine;
using System.Collections;

public class Porta : Objeto
{
    #region atributos
    bool isProntaParaAbrir;
	public AudioClip Door;
	public AudioSource source;
	public Collider2D col;
	#endregion

    #region getters e setters
    public bool IsProntaParaAbrir
    {
        get { return isProntaParaAbrir; }
        set { isProntaParaAbrir = value; }
    }
    #endregion

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && isProntaParaAbrir)
        {
            abrir();
        }
    }

    public void abrir()
    {
        source.PlayOneShot(Door, 2f);
        this.AnimadorObjeto.SetBool("abrir", true);
        this.GetComponent<BoxCollider2D>().enabled = false;
        Destroy(col);
    }

    public void fechar()
    {
        source.PlayOneShot(Door, 2f);
        this.AnimadorObjeto.SetBool("abrir", false);
        this.GetComponent<BoxCollider2D>().enabled = true;
    }
}
