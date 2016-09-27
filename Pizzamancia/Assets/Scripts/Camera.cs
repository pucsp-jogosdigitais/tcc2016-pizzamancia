using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
    #region atributos
    public Transform alvo;
    float posicaoCamera = 0;
    float posicaoAlvo = 0;
    public float velocidade;
    #endregion

    // Use this for initialization
    void Start()
    {
		if (alvo == null) {
			while (alvo == null) {
				alvo = GameObject.FindGameObjectWithTag ("Player").transform;
			}
			posicaoCamera = transform.position.z;
			posicaoAlvo = alvo.position.z;
			velocidade = 10;
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

        transform.position = Vector3.Lerp(vetorCamera, vetorAlvo, Time.smoothDeltaTime * velocidade);
    }
}
