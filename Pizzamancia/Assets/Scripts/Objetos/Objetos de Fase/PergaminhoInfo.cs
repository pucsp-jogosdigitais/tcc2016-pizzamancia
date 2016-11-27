using UnityEngine;
using System.Collections;

public class PergaminhoInfo : MonoBehaviour 
{
	public string textoConteudo;

	void OnTriggerEnter2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag.ToString() == "Player") 
		{
			CaixaTexto.getInstance ().TextoConteudo.text = textoConteudo;
			CaixaTexto.getInstance ().CaixaDeTexto.SetActive (true);
		}
	}

	void OnTriggerStay2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag.ToString() == "Player") 
		{
			CaixaTexto.getInstance ().TextoConteudo.text = textoConteudo;
			CaixaTexto.getInstance ().CaixaDeTexto.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D colisor)
	{
		if (colisor.gameObject.tag.ToString() == "Player") 
		{
			CaixaTexto.getInstance ().TextoConteudo.text = "";
			CaixaTexto.getInstance ().CaixaDeTexto.SetActive (false);
		}
	}
}
