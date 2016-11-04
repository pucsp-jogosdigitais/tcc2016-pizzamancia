using UnityEngine;
using System.Collections;

public class Plataform : MonoBehaviour
{
	bool sobe;
	bool desce;
	bool isFundoTocado;
    public Rigidbody2D rdd;
    public float posMin;
    public float posMax;

    public float velocidade;

    // Update is called once per frame
    void Update()
    {
        float pos = gameObject.transform.position.y;

		if (pos >= posMax)
        {
            sobe = false;
            desce = true;
			isFundoTocado = false;
        }

		if (pos <= posMin || isFundoTocado)
        {
            sobe = true;
            desce = false;
        }

        if (sobe == true)
        {
           // this.transform.Translate(Vector2.up * Time.deltaTime * velocidade,Space.World);
            rdd.AddForce(Vector2.up*7, ForceMode2D.Force);
        }

        if (desce == true)
        {
           // this.transform.Translate(Vector2.down * Time.deltaTime * velocidade, Space.World);
            rdd.AddForce(Vector2.down*7, ForceMode2D.Force);
        }
    }

	public bool IsFundoTocado
	{
		get { return isFundoTocado; }
		set { isFundoTocado = value; }
	}

    void OnTriggerEnter2Dold(Collider2D colisor)
    {
		if (colisor.gameObject.tag.ToString() == "Player" || 
			colisor.gameObject.tag.ToString() == "Inimigo") 
		{
			colisor.transform.parent = this.transform;
		}
    }

    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.collider.gameObject.tag.ToString() == "Player" ||
            colision.collider.gameObject.tag.ToString() == "Inimigo")
        {
            colision.collider.transform.parent = this.transform;
        }
    }
    void OnCollisionExit2D(Collision2D colision)
    {
        if (colision.collider.gameObject.tag.ToString() == "Player" ||
            colision.collider.gameObject.tag.ToString() == "Inimigo")
        {
            colision.collider.transform.parent = null;
        }
    }

    void OnTriggerExit2Dout(Collider2D colisor)
    {
		if (colisor.gameObject.tag.ToString() == "Player" || 
			colisor.gameObject.tag.ToString() == "Inimigo") 
		{
			colisor.transform.parent = null;
		}
    }
}
