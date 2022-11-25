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
    /// <summary>�擾�\���ǂ����Btrue�Ŏ擾�\�B�擾������false�ɂ��� </summary>
    public bool collectItem;
    /// <summary>���鎞�ɏo��e�L�X�g</summary>
    public string[] informationText;
    /// <summary>�J�������ɏo��e�L�X�g</summary>
    public string[] openText;
    /// <summary>��鎞�ɏo��e�L�X�g�B</summary>
    public string[] getText;
    /// <summary>�������ɏo�镔���̃e�L�X�g�B</summary>
    public string[] notFaundText;
}

[CreateAssetMenu(fileName = "Room", menuName = "CreateRoom")]
public class Room : ScriptableObject
{
    public string name;
    public string[] texts;
    /// <summary>������k�̏��œ����</summary>
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
