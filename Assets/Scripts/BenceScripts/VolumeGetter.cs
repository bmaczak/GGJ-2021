using UnityEngine;
using UnityEngine.Audio;

public class VolumeGetter : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioMixerStrings[] _mixerStrings;

    public static VolumeGetter instance;

    public void Awake()
    {
        if (instance == null)
            instance = this;

        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        Start1();
    }

    void Start1()
    {
        foreach (AudioMixerStrings audioMixerStrings in _mixerStrings)
        {
            SetMixerVolume(audioMixerStrings._prefsVolumeString, audioMixerStrings._mixerVolumeString);
        }
    }


    private void SetMixerVolume(string prefsVolumeString, string mixerVolumeString)
    {
        float prefsFloat = PlayerPrefs.GetFloat(prefsVolumeString, 0.3f);

        if (prefsFloat == 0)
        {
            prefsFloat = 0.0001f;
        }

        float volumeRange = Mathf.Log10(prefsFloat) * 20;
        _audioMixer.SetFloat(mixerVolumeString, volumeRange);
    }

}


[System.Serializable]
public class AudioMixerStrings
{
    public string _prefsVolumeString;
    public string _mixerVolumeString;
}
