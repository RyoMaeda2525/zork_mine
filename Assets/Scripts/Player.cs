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
            //î•ñ‚ª‚È‚¢‚Æ‚«‚Í•”‰®î•ñ‚ğo—Í‚µ‚ÄI‚í‚é
            if (value == null) { RoomMessageSet(); return; }

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
        _tp.MessageTextSet = _playerRoom.texts;
    }
}
