using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
    #region atributos
    Transform alvo;
    float posicaoCamera = 0;
    float posicaoAlvo = 0;
    public float velocidade;
    #endregion
    public Vector3 ajuste;
    public float folgaCamera = 2;

    // Use this for initialization
    void Start()
    {
		if (alvo == null) {
			while (alvo == null) {
				alvo = GameObject.FindGameObjectWithTag ("Player").transform;
			}

			posicaoCamera = transform.position.z;
			posicaoAlvo = alvo.position.z;
		}
	}

    // Update is called once per frame
    void LateUpdate()
    {
		if (alvo == null)
			return;
        //Vector3 vetorCamera = new Vector3(transform.position.x, transform.position.y, posicaoCamera);
        //Vector3 vetorAlvo = new Vector3(alvo.position.x, alvo.position.y, posicaoAlvo);
        Vector3 vetorCamera = new Vector3(transform.position.x, transform.position.y, posicaoCamera);
        Vector3 vetorAlvo = new Vector3(alvo.position.x, alvo.position.y, posicaoAlvo);
        Vector3 destino= vetorAlvo + ajuste;
        Vector3 vetorCameraalvo = new Vector3(transform.position.x, transform.position.y, alvo.position.z);
        float folga = Vector3.Distance(destino, vetorCameraalvo);
        transform.position = Vector3.Lerp(vetorCamera, destino, (Time.smoothDeltaTime * velocidade * vetorCamera.magnitude) * Mathf.Clamp(folga - folgaCamera, 0, 1));
    }
}
