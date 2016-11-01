using UnityEngine;
using System.Collections;

public class Plataform : MonoBehaviour
{
    Rigidbody2D rdbPlataform;

    public float posMin;
    public float posMax;
    bool sobe;
    bool desce;
    public float velocidade;

    void Start()
    {
        //rdbPlataform = this.gameObject.GetComponent<Rigidbody2D>();
    }

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
            this.transform.Translate(Vector2.down * Time.deltaTime * velocidade);
        }

        if (desce == true)
        {
            this.transform.Translate(Vector2.up * Time.deltaTime * velocidade);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //col.transform.

        col.transform.parent = this.transform;

        //col.transform.rigidbody2D
    }

    void OnTriggerExit2D(Collider2D col)
    {
        col.transform.parent = null;
    }
}
