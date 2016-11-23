using UnityEngine;
using System.Collections;

public class PlataformaY : MonoBehaviour
{
	#region atributos
	public Rigidbody2D rdbPlataforma;

	bool sobe;
	bool desce;
	bool isFundoTocado;
    public float posMin;
    public float posMax;
	public float velocidade;
	#endregion

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
			rdbPlataforma.velocity = new Vector2(0, velocidade);
        }

        if (desce == true)
        {
			rdbPlataforma.velocity = new Vector2(0, -velocidade);
        }
    }

	public bool IsFundoTocado
	{
		get { return isFundoTocado; }
		set { isFundoTocado = value; }
	}
}
