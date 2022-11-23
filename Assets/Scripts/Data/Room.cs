using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "Room", menuName = "CreateRoom")]
public class Room : ScriptableObject
{
    public string name;
    public string[] text;
    public Room[] room;

    public Room(Room room)
    {
        this.name = room.name;
        this.text = room.text;
        this.room = room.room;
    }
}
