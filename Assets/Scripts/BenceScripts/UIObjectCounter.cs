using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIObjectCounter : MonoBehaviour
{
    [SerializeField] private Text _objectCounterText;
    private int _counter;

    private void Start()
    {
        _counter = 0;
    }

    private void OnEnable()
    {
        SpawnableObject.OnObjectPickedUp += IncreaseCounter;
    }

    private void OnDisable()
    {
        SpawnableObject.OnObjectPickedUp -= IncreaseCounter;
    }

    private void IncreaseCounter()
    {
        _counter++;
        _objectCounterText.text = _counter.ToString();
    }
}
