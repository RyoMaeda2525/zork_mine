using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    TextPrinter _tp;

    [SerializeField]
    private Room _playerRoom;

    public Room PlayerRoom 
    {
        get { return _playerRoom; }

        set 
        { 
            _playerRoom = value;
            RoomMessageSet();
        }
    }

    private void Awake()
    {
        RoomMessageSet();
    }

    private void RoomMessageSet() 
    {
        _tp.MessageSet = _playerRoom.text;
    }
}
