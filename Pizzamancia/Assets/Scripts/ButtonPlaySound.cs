using UnityEngine;
using System.Collections;

public class ButtonPlaySound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip hover;
    public AudioClip click;

    public void OnHover()
    {
        source.PlayOneShot(hover, 2f);
    }
    public void OnClick()
    {
        source.PlayOneShot(click, 2f);
    }
}