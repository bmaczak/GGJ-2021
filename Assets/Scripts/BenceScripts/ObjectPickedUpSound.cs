using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ObjectPickedUpSound : MonoBehaviour
{
    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SpawnableObject.OnObjectPickedUp += PlaySound;
    }

    private void OnDisable()
    {
        SpawnableObject.OnObjectPickedUp -= PlaySound;
    }

    private void PlaySound()
    {
        _source.Play();
    }
}
