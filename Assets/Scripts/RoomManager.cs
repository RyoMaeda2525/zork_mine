using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private Room[] _rooms;

    public void RoomReset() 
    {
        foreach (var room in _rooms)
        {
            room.ItemNotSearchtexts = new string[0];

            if (room.roomItemList.Count > 0)
            {
                foreach (var item in room.roomItemList)
                {
                    item.deadBool = false;
                }
            }
        }
    }
}
