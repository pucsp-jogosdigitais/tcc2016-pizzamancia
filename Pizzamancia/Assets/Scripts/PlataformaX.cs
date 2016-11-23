using UnityEngine;
using System.Collections;

public class PlataformaX : MonoBehaviour
{
	#region atributos
    public Rigidbody2D rdbPlataforma;

    bool paraEsquerda;
    bool paraDireita;
    public float posMin;
    public float posMax;
    public float velocidade;
	#endregion

    void Start()
    {
        rdbPlataforma = this.GetComponent<Rigidbody2D>();
        velocidade = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float pos = gameObject.transform.position.x;

        if (pos >= posMax)
        {
            paraEsquerda = false;
            paraDireita = true;
        }

        if (pos <= posMin)
        {
            paraEsquerda = true;
            paraDireita = false;
        }

		if (paraEsquerda == true)
        {
            rdbPlataforma.velocity = new Vector2(velocidade, 0);
        }

		if (paraDireita == true)
        {
            rdbPlataforma.velocity = new Vector2(-velocidade, 0);
        }
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

