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
        //int ataquesLancados = 0;
        //float intervaloAtaque = 0.25f;
        //float tempoPassadoAtaque = 0;

        ataqueMagico.GetComponent<AtaqueMagico>().Dano = this.Dano;
        ataqueMagico.GetComponent<AtaqueMagico>().Velocidade = this.Velocidade;
        ataqueMagico.GetComponent<AtaqueMagico>().DuracaoAtaque = this.DuracaoAtaque;
        ataqueMagico.GetComponent<AtaqueMagico>().PosicaoRelativaInicial = new Vector3(0.3f, 0);

        for (int qtdAtq = 0; qtdAtq < this.NumeroAtaques; qtdAtq++)
        {
            float distanciaAtaque = qtdAtq * 0.1f;

            ataqueMagico.GetComponent<AtaqueMagico>().PosicaoRelativaInicial = new Vector3(0.5f + distanciaAtaque, 0);

            Instantiate(ataqueMagico, ataqueMagico.transform.position, new Quaternion());
        }

        //if (tempoPassadoAtaque < intervaloAtaque)
        //{
        //    tempoPassadoAtaque += Time.deltaTime;
        //}
        //else if (ataquesLancados <= this.NumeroAtaques)
        //{
        //    tempoPassadoAtaque = 0;
        //    ataquesLancados++;
        //    Instantiate(ataqueMagico, ataqueMagico.transform.position, new Quaternion());
        //}
    }
}
