using UnityEngine;
using System.Collections;

public class PreludioBoss : MonoBehaviour 
{
	public Boss bossRespectivo;

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag.ToString () == "Player") 
		{
            colisor.gameObject.GetComponent<Jogador>().PosicaoSpawn = new Vector2(29f, 4.6f);
			BossHUD.getInstance ().comecarLuta (bossRespectivo);
			bossRespectivo.comecarLuta ();
            Destroy(gameObject);
		}
	}
}
