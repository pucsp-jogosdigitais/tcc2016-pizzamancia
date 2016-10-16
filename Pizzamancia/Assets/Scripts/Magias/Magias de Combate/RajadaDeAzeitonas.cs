using UnityEngine;
using System.Collections;

public class RajadaDeAzeitonas : MagiaCombate
{
    #region atributos
    public GameObject ataqueMagico;
    #endregion

    // Use this for initialization
    void Start()
    {
        this.Nome = "Rajada de Azeitonas";

        this.CustoMana = 5;
        this.Cooldown = 1;
        this.TempoPassado = this.Cooldown;
        this.Duracao = 0;

        this.NumeroAtaques = 5;
        this.Dano = 1;
        this.Velocidade = 4;
        this.DuracaoAtaque = 5;
    }

    public override void conjurar()
    {
        ataqueMagico.GetComponent<AtaqueMagico>().Dano = this.Dano;
        ataqueMagico.GetComponent<AtaqueMagico>().Velocidade = this.Velocidade;
        ataqueMagico.GetComponent<AtaqueMagico>().DuracaoAtaque = this.DuracaoAtaque;

        for (int qtdAtq = 0; qtdAtq < this.NumeroAtaques; qtdAtq++)
        {
            float distanciaAtaque = qtdAtq * 0.1f;

            ataqueMagico.GetComponent<AtaqueMagico>().PosicaoRelativaInicial = new Vector3(0.3f + distanciaAtaque, 0f, 0f);

            Instantiate(ataqueMagico, ataqueMagico.transform.position, new Quaternion());
        }
    }
}
