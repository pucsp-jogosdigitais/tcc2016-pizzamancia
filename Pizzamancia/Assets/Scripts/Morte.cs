using UnityEngine;
using System.Collections;

public class Morte : MonoBehaviour
{

    public bool morre;
    public bool dano;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (morre == true)
        if (col.gameObject)
        {
            Destroy(col.gameObject);
        }

    }
}
