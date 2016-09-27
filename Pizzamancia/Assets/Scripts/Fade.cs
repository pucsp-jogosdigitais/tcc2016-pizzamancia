using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

    Image painelFade;
    public string LevelToLoad;
	public bool semClique=false;
    public static Fade fade;
    //public AudioSource source;
    //bool fadeAudio = false;

    void Awake()
    {
        fade = this;
    }
	void Start()
	{ 
        painelFade = GetComponent<Image>();
        painelFade.enabled = true;
        painelFade.CrossFadeAlpha(0.01f, 2, true);
		if (semClique == true) {
			Esperar ();
			ChangeScene (LevelToLoad);
		}
	}
	
	// Update is called once per frame


        //if (fadeAudio)
        //{
        //    source.volume = Mathf.Lerp(source.volume, 0, Time.deltaTime);
        //}//será dado um fade quando mudar a tela, então a musica irá diminuir o volume e não irá cortar abruptamente
	public void Update()
	{
		
	}

    void ChangeScene()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
	 IEnumerator Esperar (){
		yield return new WaitForSeconds (2);
	}

    public void ChangeScene(string level)
	{
		if (semClique == true) {
			Esperar ();
		}
			painelFade.CrossFadeAlpha (1, 2, true);
			LevelToLoad = level;
			Invoke ("ChangeScene", 2);
	}

}
