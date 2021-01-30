using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationYTrigger : MonoBehaviour
{
    public enum EDirection
    {
        Right,
        Left
    }

    [SerializeField] private EDirection _direction;


    public delegate void EnterTrigger(string direction);
    public static event EnterTrigger OnEnterTrigger;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (OnEnterTrigger != null)
            {
                OnEnterTrigger(_direction.ToString());
                Debug.Log("Trigger "+ _direction + " activated");
            }
        }
    }

}
