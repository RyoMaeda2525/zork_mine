using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "Room", menuName = "CreateRoom")]
public class Room : ScriptableObject
{
    public string name;
    public string[] text;
    /// <summary>������k�̏��œ����</summary>
    public Room[] rooms;

    public Room(Room room)
    {
        this.name = room.name;
        this.text = room.text;
        this.rooms = room.rooms;
    }
}
