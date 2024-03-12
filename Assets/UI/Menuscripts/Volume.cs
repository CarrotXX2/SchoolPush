using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public string backgroundMusicTag = "Background music";
    public float minVolume = 0.0f;
    public float maxVolume = 1.0f;

    void Start()
    {
        // Abonneer op de veranderende waarde van de slider
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
    }

    public void OnVolumeChanged()
    {
        float sliderValue = volumeSlider.value;

        sliderValue = Mathf.Clamp01(sliderValue);

        AudioSource[] audioSources = GameObject.FindObjectsOfType<AudioSource>();

        foreach (AudioSource source in audioSources)
        {
            if (source.CompareTag(backgroundMusicTag))
            {
                source.volume = sliderValue;
            }
        }
    }
}