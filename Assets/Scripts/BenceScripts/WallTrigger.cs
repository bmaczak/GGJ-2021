using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    public delegate void EnterTrigger(string direction);
    public static event EnterTrigger OnEnterTrigger;

    private string _tag;

    private void Start()
    {
        _tag = gameObject.tag;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (OnEnterTrigger != null)
            {
                OnEnterTrigger(_tag.ToString());
                Debug.Log("Trigger " + _tag + " activated");
            }
        }
    }
}
