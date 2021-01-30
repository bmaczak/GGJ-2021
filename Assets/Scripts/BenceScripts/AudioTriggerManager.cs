using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioTriggerManager : MonoBehaviour
{
    private bool bPlayerIsIn = false;
    private AudioSource source;
    [SerializeField] private float fFadeInTime;
    [SerializeField] private float fFadeOutTime;
    [SerializeField] private float fIncreaseIncrement;
    [SerializeField] private float fDecreaseIncrement;
    [SerializeField] private float fMinVolume;
    [SerializeField] private float fMaxVolume;
    [SerializeField] private float fTimeToFalse;
    private float currentTime;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerEntered();
        }
    }

    void LateUpdate()
    {
        if (currentTime <= 0)
        {
            bPlayerIsIn = false;
        }

        if (bPlayerIsIn)
        {
            IncreaseVolume();
        }

        else if (!bPlayerIsIn)
        {
            DecreaseVolume();
        }

        if (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
        }      
    }

    private void IncreaseVolume()
    {
        if (source.volume <= fMaxVolume)
        {
            source.volume += fIncreaseIncrement * Time.deltaTime / fFadeInTime;
        }
    }

    private void DecreaseVolume()
    {
        if (source.volume >= fMinVolume)
        {
            source.volume -= fDecreaseIncrement * Time.deltaTime / fFadeOutTime;
        }
    }

    public void PlayerEntered()
    {
        bPlayerIsIn = true;
        currentTime = fTimeToFalse;
    }
}
