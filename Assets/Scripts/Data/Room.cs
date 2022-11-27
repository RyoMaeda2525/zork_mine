using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

[Serializable]
public class RoomItem
{
    public string itemName;
    /// <summary>取得可能かどうか。trueで取得可能。取得したらfalseにする </summary>
    public bool collectItemBool;
    /// <summary>生きているキャラかどうか </summary>
    public bool lifeBool;
    /// <summary>死んでいるかの取得</summary>
    public bool deadBool;
    /// <summary>見る時に出るテキスト</summary>
    public string[] informationText;
    /// <summary>開けた時に出るテキスト</summary>
    public string[] openText;
    /// <summary>取る時に出るテキスト。</summary>
    public string[] getText;
    /// <summary>取った後に出る部屋のテキスト。</summary>
    public string[] notFaundText;
    /// <summary>ナイフで刺した際のテキスト。</summary>
    public string[] DethText;
    /// <summary>ナイフで刺された後のテキスト。</summary>
    public string[] DiedText;
    /// <summary>一緒に手に入るアイテムの名前</summary>
    public string[] getItemName;
    /// <summary>扉を開けた際に入る部屋</summary>
    public Room room;
}

[CreateAssetMenu(fileName = "Room", menuName = "CreateRoom")]
public class Room : ScriptableObject
{
    public string name;
    public string[] texts;
    public string[] ItemNotSearchtexts = null;
    /// <summary>東西南北の順で入れる</summary>
    public Room[] rooms;
    public List<RoomItem> roomItemList;

    public Room(Room room)
    {
        this.name = room.name;
        this.texts = room.texts;
        this.ItemNotSearchtexts = room.ItemNotSearchtexts;
        this.rooms = room.rooms;
        this.roomItemList = room.roomItemList;
    }
}
