using UnityEngine;
using System.Collections;

public class TelaLevelCompleto : MonoBehaviour
{
	public GameObject telaLevelCompleto; //GameObject que armazena a UI de menu de pause
	public GameObject pontosObtidos;

	Jogador jogador;

	// Use this for initialization
	void Start()
	{
		telaLevelCompleto.SetActive(false);
		jogador = GameObject.FindGameObjectWithTag ("Player").GetComponent<Jogador> ();
	}

	// Update is called once per frame
	void Update()
	{
	}

	public GameObject PontosObtidos
	{
		get { return pontosObtidos; }
		set { pontosObtidos = value; }

	}

	public void completarLevel()
	{
		jogador.IsControlavel = false;
		pontosObtidos.GetComponent<GUIText> ().text = GameManager.getInstance ().PontosLevel.ToString("0000");

		GameManager.getInstance().pararJogo();
		telaLevelCompleto.SetActive(true);
	}
		
	public void reiniciarLevel()
	{
		GameManager.getInstance().recarregarLevel();
		GameManager.getInstance().continuarJogo();
	}

	public void retornarSelecLevel()
	{
		GameManager.getInstance().carregarTela("MenuSelecLevel");
		GameManager.getInstance().continuarJogo();
	}
}
