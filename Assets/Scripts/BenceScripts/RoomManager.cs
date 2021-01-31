using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private Room[] _rooms;
    private int _activeRoom = -1;
    private GameObject _activeSpawnedObject;

    void Start()
    {
        InitRoomManager();
        InitiateNewSpawn();
    }

    private void OnEnable()
    {
        Room.OnEnterRoom += UpdateActiveRoom;
        Room.OnNewObjectSpawned += UpdateActiveObject;
        SpawnableObject.OnObjectPickedUp += InitiateNewSpawn;
    }

    private void OnDisable()
    {
        Room.OnEnterRoom -= UpdateActiveRoom;
        Room.OnNewObjectSpawned -= UpdateActiveObject;
        SpawnableObject.OnObjectPickedUp -= InitiateNewSpawn;
    }

    private void InitRoomManager()
    {
        for(int i = 0; i < _rooms.Length; i++)
        {
            _rooms[i].InitRoom(i);
        }
    }

    void UpdateActiveRoom(int activeRoom)
    {
        _activeRoom = activeRoom;
        Debug.Log("Active room is: " + (_activeRoom + 1).ToString());
    }

    private void InitiateNewSpawn()
    {
        int roomToSpawn = Random.Range(0, _rooms.Length);

        if (roomToSpawn == _activeRoom)
        {
            InitiateNewSpawn();
            return;
        }

        _rooms[roomToSpawn].Spawn();
    }

    public void UpdateActiveObject(GameObject activeObject)
    {
        _activeSpawnedObject = activeObject;
    }
}
