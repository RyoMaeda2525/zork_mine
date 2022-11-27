using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    [SerializeField]
    TextPrinter _tp;

    [SerializeField]
    private Room _playerRoom;

    private Regex roomRegex = new Regex("•”‰®");

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
        if (_playerRoom.ItemNotSearchtexts.Length == 0)
        {
            _tp.MessageTextSet = _playerRoom.texts;
        }
        else
        {
            _tp.MessageTextSet = _playerRoom.ItemNotSearchtexts;
        }

        if (roomRegex.IsMatch(_playerRoom.name))
        { RoomCenter(); }
    }

    public void RoomCenter()
    {
        string[] rooms = new string[4];

        if (_playerRoom.rooms[0] != null)
        { rooms[0] = $"“Œ :{_playerRoom.rooms[0].name}"; }

        if (_playerRoom.rooms[1] != null)
        { rooms[1] = $"¼ :{_playerRoom.rooms[1].name}"; }

        if (_playerRoom.rooms[2] != null)
        { rooms[2] = $"“ì :{_playerRoom.rooms[2].name}"; }

        if (_playerRoom.rooms[3] != null)
        { rooms[3] = $"–k :{_playerRoom.rooms[3].name}"; }

        _tp.CenterRoomText(rooms);
    }
}
