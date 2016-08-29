﻿using UnityEngine;
using System.Collections;

public class MenuPause : MonoBehaviour
{
    public GameObject menuDePause; //GameObject que armazena a UI de menu de pause
    public GameObject painelReiniciarLevel;
    public GameObject painelSelecLevel;
    public GameObject painelSairJogo;

    bool isPaused; //informa se o jogo está pausado ou nao

    // Use this for initialization
    void Start()
    {
        menuDePause.SetActive(false);
        painelReiniciarLevel.SetActive(false);
        painelSelecLevel.SetActive(false);
        painelSairJogo.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!isPaused)
            {
                pausarJogo();
            }
            else
            {
                if (painelReiniciarLevel.activeInHierarchy)
                {
                    painelReiniciarLevel.SetActive(false);
                }
                else if (painelSelecLevel.activeInHierarchy)
                {
                    painelSelecLevel.SetActive(false);
                }
                else if (painelSairJogo.activeInHierarchy)
                {
                    painelSairJogo.SetActive(false);
                }
                else
                {
                    retomarJogo();
                }
            }
        }
    }

    //pausa o jogo
    public void pausarJogo()
    {
        isPaused = true;

        GameManager.getInstance().pararJogo();
        menuDePause.SetActive(true);
    }

    //retoma o jogo pausado
    public void retomarJogo()
    {
        isPaused = false;

        GameManager.getInstance().continuarJogo();
        menuDePause.SetActive(false);
        painelReiniciarLevel.SetActive(false);
        painelSelecLevel.SetActive(false);
        painelSairJogo.SetActive(false);
    }

    public void reiniciarLevel()
    {
        isPaused = false;

        GameManager.getInstance().recarregarLevel();
        GameManager.getInstance().continuarJogo();
    }

    public void retornarSelecLevel()
    {
        isPaused = false;

        GameManager.getInstance().carregarTela("MenuSelecLevel");
        GameManager.getInstance().continuarJogo();
    }
}
