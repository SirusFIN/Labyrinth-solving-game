using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instanse;
    public float volume = 0.5f;

    private AudioSource soundtrack;

    private void Awake()
    {

        if (Instanse != null && Instanse != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instanse = this;
            DontDestroyOnLoad(gameObject);
            soundtrack = gameObject.GetComponent<AudioSource>();
        }
    }


    public void SetVolume()
    {
        volume = GameObject.Find("Slider").GetComponent<Slider>().value;
        soundtrack.volume = volume;
    }
}
