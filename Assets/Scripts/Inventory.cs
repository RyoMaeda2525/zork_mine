using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    [SerializeField]
    private TextPrinter _tp;

    [SerializeField]
    private GameManager _gm;

    public List<RoomItem> _roomItems;

    public void Use(RoomItem useItem, RoomItem useToItem)
    {
        switch (useItem.itemName)
        {
            case "ナイフ":
                if (!useToItem.deadBool && useToItem.itemName != "ナイフ") 
                {
                    _tp.TextPrint($"ナイフで{useToItem.itemName}を刺した");
                    if (useToItem.lifeBool) 
                    {
                        _gm.DeadItemSet(useToItem);
                    }
                    _tp.MessageTextSet = useToItem.DethText;
                    useToItem.deadBool = true;
                }
                else 
                {
                    _tp.MessageTextSet = useToItem.DiedText;
                }
                break;

            case "少女":
                if (useToItem.itemName == "水槽") 
                {
                    _gm.Ending();
                }
                break;

            case "ペンダント":
                if (useToItem.itemName == "少女") 
                {
                    _tp.TextPrint($"ペンダントを少女の首に掛けた。その時あなたは");
                    _tp.TextPrint($"ペンダントの表面にある血が");
                    _tp.TextPrint($"自分から見て少女の右側から出ていることに気づく。");
                }
                break;
        }
    }

    public bool ItemSearch(RoomItem item) 
    {
        if (_roomItems.Contains(item)) 
        {
            return false;
        }
        return true;
    }
}
