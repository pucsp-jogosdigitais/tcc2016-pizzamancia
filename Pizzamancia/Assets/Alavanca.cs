using UnityEngine;
using System.Collections;

public class Alavanca : MonoBehaviour {
    public GameObject Spikes;
    public Animator anim;
	// Use this for initialization
    void OnTriggerEnter2D(Collider2D col)
    {
        anim.SetBool("ativada", true);
        Destroy(Spikes);
    }
}
