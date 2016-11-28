using UnityEngine;
using System.Collections;

public class RajadaDeAzeitonas : MagiaCombate
{
    #region atributos
    public GameObject ataqueMagico;
    #endregion

    void Start()
    {
        this.Nome = "Rajada de Azeitonas";

        this.CustoMana = 5;
        this.Cooldown = 1;
        this.TempoPassado = this.Cooldown;
        this.Duracao = 0;

        this.NumeroAtaques = 5;
        this.Dano = 1;
        this.Velocidade = 6;
        this.DuracaoAtaque = 5;
    }

    public override void conjurar()
    {
        ataqueMagico.GetComponent<AtaqueMagico>().Dano = this.Dano;
        ataqueMagico.GetComponent<AtaqueMagico>().Velocidade = this.Velocidade;
        ataqueMagico.GetComponent<AtaqueMagico>().DuracaoAtaque = this.DuracaoAtaque;
        ataqueMagico.GetComponent<AtaqueMagico>().PosicaoRelativaInicial = new Vector3(0.3f, 0);

        for (int qtdAtq = 0; qtdAtq < this.NumeroAtaques; qtdAtq++)
        {
            float distanciaAtaque = qtdAtq * 0.175f;

            ataqueMagico.GetComponent<AtaqueMagico>().PosicaoRelativaInicial = new Vector3(0.5f + distanciaAtaque, 0);

            Instantiate(ataqueMagico, ataqueMagico.transform.position, new Quaternion());
        }
    }
}
