using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private GameObject soundtrack;

    // Start is called before the first frame update
    void Start()
    {
        soundtrack = GameObject.Find("Soundtrack");
        SetSlider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSlider()
    {
        gameObject.GetComponent<Slider>().value = soundtrack.GetComponent<AudioManager>().volume;
    }

    public void UpdatedVolume()
    {
        float value = gameObject.GetComponent<Slider>().value;
        soundtrack.GetComponent<AudioManager>().volume = value;
        soundtrack.GetComponent<AudioSource>().volume = value;
    }
}
