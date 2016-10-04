using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{

    Image painelFade;
    public string LevelToLoad;
    public bool semClique = false;
    public static Fade fade;
    public float tempoEspera;
    float tempoFading = 1.5f;

    void Awake()
    {
        fade = this;
    }
    void Start()
    {
        painelFade = GetComponent<Image>();
        painelFade.enabled = true;
        painelFade.CrossFadeAlpha(0.01f, tempoFading, true);
        if (semClique == true)
        {
            StartCoroutine(Esperar());
        }
    }

    void ChangeScene()
    {
        painelFade.CrossFadeAlpha(1, tempoFading, true);
        SceneManager.LoadScene(LevelToLoad);
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(tempoEspera);
        ChangeScene(LevelToLoad);
    }

    public void ChangeScene(string level)
    {
        painelFade.CrossFadeAlpha(1, tempoFading, true);
        LevelToLoad = level;
        Invoke("ChangeScene", tempoEspera);
    }
}
