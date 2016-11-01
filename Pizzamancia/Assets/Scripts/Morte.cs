using UnityEngine;
using System.Collections;

public class Morte : MonoBehaviour
{
    public bool morre;
    public bool dano;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (morre == true && col.gameObject)
        {
            Destroy(col.gameObject);
        }
    }
}
