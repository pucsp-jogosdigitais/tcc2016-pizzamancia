using UnityEngine;
using System.Collections;

public class ObjetivoLevel : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameManager.getInstance().IsLevelCompleto = true;
        }
    }
}
