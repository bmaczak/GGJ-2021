using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObject : MonoBehaviour
{
    private bool _playerHit;

    public delegate void ObjectPickedUp();
    public static event ObjectPickedUp OnObjectPickedUp;

    private void Start()
    {
        _playerHit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_playerHit)
        {
            _playerHit = true;

            if (OnObjectPickedUp != null)
            {
                OnObjectPickedUp();
            }

            Destroy(gameObject);
        }
    }
}
