using UnityEngine;
using System.Collections;

public class PowerUp : Objeto
{
    public AudioClip somPego;

    public AudioClip SomPego
    {
        get { return somPego; }
        set { somPego = value; }
    }
}
