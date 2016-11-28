using UnityEngine;
using System.Collections;

public class DiscoDeCalabresa : MagiaCombate
{
    #region atributos
    public GameObject ataqueMagico;
    #endregion

    void Start()
    {
        this.Nome = "Disco de Calabresa";

        this.CustoMana = 10;
        this.Cooldown = 5;
        this.TempoPassado = this.Cooldown;
        this.Duracao = 0;

        this.NumeroAtaques = 1;
        this.Dano = 10;
        this.Velocidade = 4;
        this.DuracaoAtaque = 5;
    }

    public override void conjurar()
    {
        ataqueMagico.GetComponent<AtaqueMagico>().Dano = this.Dano;
        ataqueMagico.GetComponent<AtaqueMagico>().PosicaoRelativaInicial = new Vector3(0.3f, 0);
        ataqueMagico.GetComponent<AtaqueMagico>().Velocidade = this.Velocidade;
        ataqueMagico.GetComponent<AtaqueMagico>().DuracaoAtaque = this.DuracaoAtaque;

        Instantiate(ataqueMagico, ataqueMagico.transform.position, new Quaternion());
    }
}
