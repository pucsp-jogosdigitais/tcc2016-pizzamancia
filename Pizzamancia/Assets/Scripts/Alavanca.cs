using UnityEngine;
using System.Collections;

public class Alavanca : MonoBehaviour {
    public GameObject Spikes;
    public Animator anim;
	public AudioClip lever;
	public AudioSource source;
	public Collider2D col;
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
			source.PlayOneShot (lever, 2f);
            anim.SetBool("ativada", true);
            Destroy(Spikes);
			Destroy(col);
        }
    }
}
