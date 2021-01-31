using TMPro;
using UnityEngine;

public class UIObjectCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _objectCounterText;
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
        _objectCounterText.text = "Collected: " + _counter.ToString();
    }
}
