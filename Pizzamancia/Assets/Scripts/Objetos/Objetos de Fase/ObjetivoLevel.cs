using UnityEngine;
using System.Collections;

public class ObjetivoLevel : MonoBehaviour
{
	public AudioSource audioSourceTela;
	public AudioClip completo;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
		{
			audioSourceTela.PlayOneShot(completo, 5f);
            GameManager.getInstance().IsLevelCompleto = true;
        }
    }
}
