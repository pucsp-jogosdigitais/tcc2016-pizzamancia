using UnityEngine;
using System.Collections;

public class Plataform : MonoBehaviour
{
	public Rigidbody2D rdbPlataforma;

	bool sobe;
	bool desce;
	bool isFundoTocado;
    public float posMin;
    public float posMax;
	public float velocidade;

	void Start() 
	{
		rdbPlataforma = this.GetComponent<Rigidbody2D> ();
		velocidade = 1.5f;
	}

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
			//this.transform.Translate(Vector2.up * Time.deltaTime * velocidade,Space.World);
			//rdbPlataforma.AddForce(Vector2.up * 7, ForceMode2D.Force);
			rdbPlataforma.velocity = new Vector2(0, velocidade);
        }

        if (desce == true)
        {
            //this.transform.Translate(Vector2.down * Time.deltaTime * velocidade, Space.World);
			//rdbPlataforma.AddForce(Vector2.down * 7, ForceMode2D.Force);
			rdbPlataforma.velocity = new Vector2(0, -velocidade);
        }
    }

	public bool IsFundoTocado
	{
		get { return isFundoTocado; }
		set { isFundoTocado = value; }
	}

    /*void OnTriggerEnter2D(Collider2D colisor)
    {
		if (colisor.gameObject.tag.ToString() == "Player" || 
			colisor.gameObject.tag.ToString() == "Inimigo") 
		{
			colisor.transform.parent = this.transform;
		}
    }

    void OnTriggerExit2D(Collider2D colisor)
    {
		if (colisor.gameObject.tag.ToString() == "Player" || 
			colisor.gameObject.tag.ToString() == "Inimigo") 
		{
			colisor.transform.parent = null;
		}
    }*/
}
