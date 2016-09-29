using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

    Image painelFade;
    public string LevelToLoad;
	public bool semClique=false;
    public static Fade fade;

    
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

			painelFade.CrossFadeAlpha (1, 2, true);
			LevelToLoad = level;
			Invoke ("ChangeScene", 2);
	}

}
