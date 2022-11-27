using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

[Serializable]
public class RoomItem
{
    public string itemName;
    /// <summary>�擾�\���ǂ����Btrue�Ŏ擾�\�B�擾������false�ɂ��� </summary>
    public bool collectItemBool;
    /// <summary>�����Ă���L�������ǂ��� </summary>
    public bool lifeBool;
    /// <summary>����ł��邩�̎擾</summary>
    public bool deadBool;
    /// <summary>���鎞�ɏo��e�L�X�g</summary>
    public string[] informationText;
    /// <summary>�J�������ɏo��e�L�X�g</summary>
    public string[] openText;
    /// <summary>��鎞�ɏo��e�L�X�g�B</summary>
    public string[] getText;
    /// <summary>�������ɏo�镔���̃e�L�X�g�B</summary>
    public string[] notFaundText;
    /// <summary>�i�C�t�Ŏh�����ۂ̃e�L�X�g�B</summary>
    public string[] DethText;
    /// <summary>�i�C�t�Ŏh���ꂽ��̃e�L�X�g�B</summary>
    public string[] DiedText;
    /// <summary>�ꏏ�Ɏ�ɓ���A�C�e���̖��O</summary>
    public string[] getItemName;
    /// <summary>�����J�����ۂɓ��镔��</summary>
    public Room room;
}

[CreateAssetMenu(fileName = "Room", menuName = "CreateRoom")]
public class Room : ScriptableObject
{
    public string name;
    public string[] texts;
    public string[] ItemNotSearchtexts = null;
    /// <summary>������k�̏��œ����</summary>
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
