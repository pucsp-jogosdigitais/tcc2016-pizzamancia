using UnityEngine;
using System.Collections;

public class Alavanca : MonoBehaviour {
    public GameObject lever;
	// Use this for initialization
    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(lever);
    }
}
