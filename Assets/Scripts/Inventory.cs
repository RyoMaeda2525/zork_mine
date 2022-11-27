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
            case "�i�C�t":
                if (!useToItem.deadBool && useToItem.itemName != "�i�C�t") 
                {
                    _tp.TextPrint($"�i�C�t��{useToItem.itemName}���h����");
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

            case "����":
                if (useToItem.itemName == "����") 
                {
                    _gm.Ending();
                }
                break;

            case "�y���_���g":
                if (useToItem.itemName == "����") 
                {
                    _tp.TextPrint($"�y���_���g�������̎�Ɋ|�����B���̎����Ȃ���");
                    _tp.TextPrint($"�y���_���g�̕\�ʂɂ��錌��");
                    _tp.TextPrint($"�������猩�ď����̉E������o�Ă��邱�ƂɋC�Â��B");
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
