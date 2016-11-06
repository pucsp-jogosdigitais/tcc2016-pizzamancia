using UnityEngine;
using System.Collections;

public class Paralax : MonoBehaviour
{
    public Material currentMaterial;
    public float offset;
    public Rigidbody2D jogadorRig;
    float direcao;
    // Use this for initialization
    void Start()
    {
        currentMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (jogadorRig.velocity.magnitude >= 0.01)
        {
			direcao = jogadorRig.gameObject.transform.localScale.x >= 1 ? 1.0f : -1.0f;
			currentMaterial.SetTextureOffset("_MainTex", new Vector2(((offset/10000) * direcao + currentMaterial.GetTextureOffset("_MainTex").x), 0.0f));


        }
    }
}
