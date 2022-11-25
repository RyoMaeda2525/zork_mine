using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using static UnityEditor.Progress;

[Serializable]
public class RoomItem
{
    public string itemName;
    /// <summary>取得可能かどうか。trueで取得可能。取得したらfalseにする </summary>
    public bool collectItem;
    /// <summary>見る時に出るテキスト</summary>
    public string[] informationText;
    /// <summary>開けた時に出るテキスト</summary>
    public string[] openText;
    /// <summary>取る時に出るテキスト。</summary>
    public string[] getText;
    /// <summary>取った後に出る部屋のテキスト。</summary>
    public string[] notFaundText;
}

[CreateAssetMenu(fileName = "Room", menuName = "CreateRoom")]
public class Room : ScriptableObject
{
    public string name;
    public string[] texts;
    /// <summary>東西南北の順で入れる</summary>
    public Room[] rooms;
    public List<RoomItem> roomItemList;

    public Room(Room room)
    {
        this.name = room.name;
        this.texts = room.texts;
        this.rooms = room.rooms;
        this.roomItemList = room.roomItemList;
    }
}
