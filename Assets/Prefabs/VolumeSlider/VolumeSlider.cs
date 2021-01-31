using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _mixerVolumeString;
    [SerializeField] private string _prefsVolumeString;
    [SerializeField] private Slider _slider;

    private float _prefsVolumeFloat;

    void Start()
    {
        SetVolumeBars();
    }

    public void SetVolumeMusic(float volumeNorm)
    {
        if (volumeNorm == 0)
        {
            volumeNorm = 0.0001f;
        }
        float volumeRange = Mathf.Log10(volumeNorm) * 20;
        _audioMixer.SetFloat(_mixerVolumeString, volumeRange);

        PlayerPrefs.SetFloat(_prefsVolumeString, volumeNorm);
    }

    public void SetVolumeBars()
    {
        _prefsVolumeFloat = PlayerPrefs.GetFloat(_prefsVolumeString, 0.3f);

        _slider.value = _prefsVolumeFloat;

        SetVolumeMusic(_prefsVolumeFloat);
    }
}
