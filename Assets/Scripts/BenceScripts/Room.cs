using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject[] _spawnableObjects;
    private AudioTriggerManager _audioManager;
    private bool _playerIsIn = false;
    private int _roomIndex;

    public delegate void EnterRoomTrigger(int roomIndex);
    public static event EnterRoomTrigger OnEnterRoom;

    public delegate void NewActiveObject(GameObject activeObject);
    public static event NewActiveObject OnNewObjectSpawned;

    public void InitRoom(int roomIndex)
    {
        _audioManager = GetComponent<AudioTriggerManager>();
        _roomIndex = roomIndex;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _audioManager.PlayerEntered();

            if (OnEnterRoom != null && !_playerIsIn)
            {
                OnEnterRoom(_roomIndex);
                _playerIsIn = true;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerIsIn = false;
        }
    }

    public void Spawn()
    {
        int spawnPointIndex = Random.Range(0, _spawnPoints.Length);
        int spawnObjectIndex = Random.Range(0, _spawnableObjects.Length);

        GameObject spawnedObject =  Instantiate(_spawnableObjects[spawnObjectIndex], _spawnPoints[spawnPointIndex].position, _spawnPoints[spawnPointIndex].rotation);
        spawnedObject.transform.parent = (this.transform);

        if(OnNewObjectSpawned != null)
        {
            OnNewObjectSpawned(spawnedObject);
        }
    }    
}
