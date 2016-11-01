using UnityEngine;
using System.Collections;

public class Plataform : MonoBehaviour
{
    public float posMin;
    public float posMax;
    bool sobe;
    bool desce;
    public float velocidade;

    // Update is called once per frame
    void Update()
    {
        float pos = gameObject.transform.position.y;
        if (pos >= posMax)
        {
            sobe = true;
            desce = false;
        }
        if (pos <= posMin)
        {
            sobe = false;
            desce = true;
        }
        if (sobe == true)
        {
			transform.Translate(Vector2.down * Time.deltaTime * velocidade);
        }
        if (desce == true)
        {
			transform.Translate(Vector2.up * Time.deltaTime * velocidade);
        }


    }
	void OnTriggerEnter2D(Collider2D col)
	{
		col.transform.parent = transform;
	}
	void OnTriggerExit2D(Collider2D col)
	{
		col.transform.parent = null;
	}
}
