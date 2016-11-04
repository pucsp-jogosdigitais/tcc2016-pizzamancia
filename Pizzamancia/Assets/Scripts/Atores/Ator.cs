using UnityEngine;
using System.Collections;

public class Ator : MonoBehaviour
{
	//essa classe serve para representar caracteristicas básicas de
	//todos os personagens do game, funcionando como uma classe-pai para
	//as demais classes que serao responsaveis pelo funcionamento de
	//personagens jogaveis, NPC's, mobs e bosses

	#region atributos

	//animacao
	public Animator animadorAtor;
	//animator do ator

	//Rigidbody e colisao
	public Rigidbody2D rdbAtor;
	//rigidbody do ator

	//ponto de spawn
	public Vector2 posicaoSpawn;
	//posicao onde o ator (re)comeca

	//movimentacao
	float metadeLargura;
	//distancia entre as bordas verticais do ator e o seu centro
	float metadeAltura;
	//distancia entre as bordas horizontais do ator e o seu centro
	float movimentoX;
	//movimento do ator no eixo X
	public float velocidadeOriginal;
	public float velocidade;
	//velocidade com a qual o ator se move
	public bool isNoChao;
	//booleana que mostra se ator esta colidindo com o chao ou nao
	public float forcaPuloOriginal;
	public float forcaPulo;
	//forca do pulo

	//ataque melee
	bool isComecouAtaque;
	//booleana que indica se o ator comecou o processo de ataque ou nao
	bool isAtacou;
	//booleana que indica se ator ja executou taque
	public Hitbox hitboxAtor;
	public float demoraAntesAtaqueOriginal;
	public float demoraAntesAtaque;
	//tempo que demora entre o inicio do ataque a sua execucao
	public float demoraDepoisAtaqueOriginal;
	public float demoraDepoisAtaque;
	//tempo que demora entre a execucao do ataque e a sua finalizacao
	float tempoPassadoInicioAtaque;
	//tempo passado desde o inicio do ataque

	//vida
	public int vidaTotalOriginal;
	public int vidaTotal;
	//quantos pontos de vida o ator tem no total
	public int vidaAtual;
	//quantos pontos de vida o ator tem no momento

	//atordoamento
	bool isAtordoado;
	float tempoAtordoamento;
	float tempoAtordoamentoPassado;

	#endregion

	void Awake ()
	{
		animadorAtor = this.GetComponent<Animator> ();

		rdbAtor = this.GetComponent<Rigidbody2D> ();

		posicaoSpawn = this.transform.position;
		metadeLargura = this.GetComponent<Renderer> ().bounds.size.x / 4;
		metadeAltura = (this.GetComponent<Renderer> ().bounds.size.y / 2) + 0.1f;

		isComecouAtaque = false;
		isAtacou = false;
		tempoPassadoInicioAtaque = 0;
	}

	void FixedUpdate ()
	{
		Vector2 ladoEsq = new Vector2 (this.transform.position.x - metadeLargura, this.transform.position.y);
		Vector2 ladoDir = new Vector2 (this.transform.position.x + metadeLargura, this.transform.position.y);
		RaycastHit2D raycastEsq = Physics2D.Raycast (ladoEsq, Vector2.down);
		RaycastHit2D raycastCentro = Physics2D.Raycast (this.transform.position, Vector2.down);
		RaycastHit2D raycastDir = Physics2D.Raycast (ladoDir, Vector2.down);
		//Debug.DrawRay(ladoEsq, Vector2.down);
		//Debug.DrawRay(this.transform.position, Vector2.down);
		//Debug.DrawRay(ladoDir, Vector2.down);
		//float distanciaLadoEsqChao = raycastEsq.distance;
		//float distanciaCentroChao = raycastCentro.distance;
		//float distanciaLadoDirChao = raycastDir.distance;

		if ((raycastEsq.distance <= metadeAltura) || (raycastCentro.distance <= metadeAltura) || (raycastDir.distance <= metadeAltura)) {
			isNoChao = true;
		} else {
			isNoChao = false;
		}

		if (isComecouAtaque) {
			movimentoX = 0;
			tempoPassadoInicioAtaque += Time.deltaTime;

			if (tempoPassadoInicioAtaque >= demoraAntesAtaque && !isAtacou) {
				executarAtaque ();
			}

			if (tempoPassadoInicioAtaque >= (demoraAntesAtaque + demoraDepoisAtaque)) {
				terminarAtaque ();
			}
		}

		andar ();
	}

	#region getters e setters

	public Animator AnimadorAtor {
		get { return animadorAtor; }
		set { animadorAtor = value; }
	}

	public Rigidbody2D RdbAtor {
		get { return rdbAtor; }
		set { rdbAtor = value; }
	}

	public Vector2 PosicaoSpawn {
		get { return posicaoSpawn; }
		set { posicaoSpawn = value; }
	}

	public float MovimentoX {
		get { return movimentoX; }
		set { movimentoX = value; }
	}

	public float VelocidadeOriginal {
		get { return velocidadeOriginal; }
		set { velocidadeOriginal = value; }
	}

	public float Velocidade {
		get { return velocidade; }
		set { velocidade = value; }
	}

	public bool IsNoChao {
		get { return isNoChao; }
		set { isNoChao = value; }
	}

	public float ForcaPuloOriginal {
		get { return forcaPuloOriginal; }
		set { forcaPuloOriginal = value; }
	}

	public float ForcaPulo {
		get { return forcaPulo; }
		set { forcaPulo = value; }
	}

	public bool IsComecouAtaque {
		get { return isComecouAtaque; }
		set { isComecouAtaque = value; }
	}

	public bool IsAtacou {
		get { return isAtacou; }
		set { isAtacou = value; }
	}

	public Hitbox HitboxAtor {
		get { return hitboxAtor; }
		set { hitboxAtor = value; }
	}

	public float DemoraAntesAtaqueOriginal {
		get { return demoraAntesAtaqueOriginal; }
		set { demoraAntesAtaqueOriginal = value; }
	}

	public float DemoraAntesAtaque {
		get { return demoraAntesAtaque; }
		set { demoraAntesAtaque = value; }
	}

	public float DemoraDepoisAtaqueOriginal {
		get { return demoraDepoisAtaqueOriginal; }
		set { demoraDepoisAtaqueOriginal = value; }
	}

	public float DemoraDepoisAtaque {
		get { return demoraDepoisAtaque; }
		set { demoraDepoisAtaque = value; }
	}

	public int VidaTotalOriginal {
		get { return vidaTotalOriginal; }
		set { vidaTotalOriginal = value; }
	}

	public int VidaTotal {
		get { return vidaTotal; }
		set { vidaTotal = value; }
	}

	public int VidaAtual {
		get { return vidaAtual; }
		set { vidaAtual = value; }
	}

	#endregion

	#region acoes

	//faz o ator andar
	public void andar ()
	{
		animadorAtor.SetFloat ("andar", Mathf.Abs (movimentoX));

		if (movimentoX > 0) {
			this.transform.localScale = new Vector2 (1, this.transform.localScale.y);
		}

		if (movimentoX < 0) {
			this.transform.localScale = new Vector2 (-1, this.transform.localScale.y);
		}

		//rdbAtor.velocity = new Vector2(movimentoX * velocidade, rdbAtor.velocity.y);
		rdbAtor.AddForce (new Vector2 (movimentoX, 0) * 10);

		if (Mathf.Abs (rdbAtor.velocity.x) > velocidade) {
			rdbAtor.velocity = new Vector2 (rdbAtor.velocity.normalized.x * velocidade, rdbAtor.velocity.y);
		}
	}

	//faz o ator pular
	public void pular (bool isPular)
	{
		if (isPular && isNoChao && !isComecouAtaque) {
			animadorAtor.SetTrigger ("pular");
			rdbAtor.AddForce (Vector2.up * forcaPulo, ForceMode2D.Impulse);
		}
	}

	public void comecarAtaque (bool isAtacar)
	{
		if (isAtacar && !isComecouAtaque) {
			animadorAtor.SetTrigger ("atacar");
			isComecouAtaque = true;
		} else {
			animadorAtor.SetBool ("atacar", false);
		}
	}

	#endregion

	#region alteracao de status

	public void executarAtaque ()
	{
		isAtacou = true;

		hitboxAtor.atingir ();
	}

	public void terminarAtaque ()
	{
		isComecouAtaque = false;
		isAtacou = false;
		tempoPassadoInicioAtaque = 0;
	}

	//aumenta ou diminui os pontos de vida atual
	public void alterarVida (int valor)
	{
		int resultadoFinal = vidaAtual + valor;

		if (resultadoFinal > vidaTotal) {
			vidaAtual = vidaTotal;
		} else if (resultadoFinal <= 0) {
			vidaAtual = 0;
			morrer ();
		} else {
			vidaAtual += valor;
		}
	}

	//mata (destroi) o ator
	public virtual void morrer ()
	{
	}

	#endregion
}
