using UnityEngine;
using System.Collections;

public class Objeto : MonoBehaviour
{
    #region atributos
    //animacao
    public Animator animadorObjeto;

    //Rigidbody e colisao
    public Rigidbody2D rdbObjeto;

    //funcionamento
    public float tempoVida;
    public float velocidade;
    #endregion

    // Use this for initialization
    void Start()
    {
		animadorObjeto = this.GetComponent<Animator>();

        rdbObjeto = this.GetComponent<Rigidbody2D>();

        if (tempoVida > 0)
        {
            Destroy(gameObject, tempoVida);
        }
    }

    #region getters e setters
    public Animator AnimadorObjeto
    {
        get { return animadorObjeto; }
        set { animadorObjeto = value; }
    }

    public Rigidbody2D RdbObjeto
    {
        get { return rdbObjeto; }
        set { rdbObjeto = value; }
    }

    public float TempoVida
    {
        get { return tempoVida; }
        set { tempoVida = value; }
    }

    public float Velocidade
    {
        get { return velocidade; }
        set { velocidade = value; }
    }
    #endregion
}
