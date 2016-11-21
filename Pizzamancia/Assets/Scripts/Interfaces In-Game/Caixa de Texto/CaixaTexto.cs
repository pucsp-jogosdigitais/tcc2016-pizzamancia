using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CaixaTexto : MonoBehaviour
{
    #region atributos
    public static CaixaTexto caixaTextoInst;
    Jogador jogador;
    GameObject caixaDeTexto;
    Text textoConteudo;
    #endregion

    // Use this for initialization
    void Start()
    {
        caixaTextoInst = this;
        jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jogador>();
        caixaDeTexto = GameObject.Find("Caixa de Texto");
        textoConteudo = GameObject.Find("Texto Conteudo").GetComponent<Text>();

        caixaDeTexto.SetActive(false);
    }

    public static CaixaTexto getInstance()
    {
        return caixaTextoInst;
    }

    public GameObject CaixaDeTexto
    {
        get { return caixaDeTexto; }
        set { caixaDeTexto = value; }
    }

    public Text TextoConteudo
    {
        get { return textoConteudo; }
        set { textoConteudo = value; }
    }
}
