using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

    Image painelFade;
    public string LevelToLoad;
	public bool semClique=false;
    public static Fade fade;
    public float tempoEsperaProximaCena = 2;
    public float tempoDuracaoFade = 2;
        
    void Awake()
    {
        fade = this;
    }
   void Start()
	{ 
        painelFade = GetComponent<Image>();
        painelFade.enabled = true;
        painelFade.CrossFadeAlpha(0.01f, tempoDuracaoFade, true);
        if (semClique == true)
        {
            Esperar();
            ChangeScene(LevelToLoad);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
	
    IEnumerator Esperar (){
         yield return new WaitForSeconds(tempoEsperaProximaCena);
    }

    public void ChangeScene(string level)
	{
        painelFade.CrossFadeAlpha(1, tempoDuracaoFade, true);
		LevelToLoad = level;
        Invoke("ChangeScene", tempoEsperaProximaCena);
	}
}
