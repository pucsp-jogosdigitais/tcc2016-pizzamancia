using UnityEngine;
using System.Collections;

public class Plataform : MonoBehaviour
{
	bool sobe;
	bool desce;
	bool isFundoTocado;

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
            this.transform.Translate(Vector2.up * Time.deltaTime * velocidade);
        }

        if (desce == true)
        {
			this.transform.Translate(Vector2.down * Time.deltaTime * velocidade);
        }
    }

	public bool IsFundoTocado
	{
		get { return isFundoTocado; }
		set { isFundoTocado = value; }
	}

    void OnTriggerEnter2D(Collider2D colisor)
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
    }
}
