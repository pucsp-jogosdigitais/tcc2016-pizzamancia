using UnityEngine;
using System.Collections;

public class Obstaculo : Objeto
{
    #region atributos
    //vida
    bool isDestrutivel;
    public int vidaTotal;
    public int vidaAtual;
    #endregion

    // Use this for initialization
    void Start()
    {
        if (vidaTotal > 0)
        {
            IsDestrutivel = true;
        }
    }

    #region getters e setters
    public bool IsDestrutivel
    {
        get { return isDestrutivel; }
        set { isDestrutivel = value; }
    }

    public int VidaTotal
    {
        get { return vidaTotal; }
        set { vidaTotal = value; }
    }

    public int VidaAtual
    {
        get { return vidaAtual; }
        set { vidaAtual = value; }
    }
    #endregion

    #region alteracoes de status
    //aumenta ou diminui os pontos de vida atual
    public void alterarVida(int valor)
    {
		if (isDestrutivel) {
        	int resultadoFinal = vidaAtual + valor;

        	if (resultadoFinal > vidaTotal)
        	{
            	vidaAtual = vidaTotal;
        	}
        	else if (resultadoFinal <= 0)
        	{
            	Destroy(this.gameObject);
        	}
        	else
        	{
            	vidaAtual += valor;
        	}
		}
    }
    #endregion
}
