using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class InputText : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    GameManager _gm;

    [SerializeField]
    private TextPrinter _tp;

    private Regex _get = new Regex("を取る");

    private Regex _look = new Regex("を見る");

    private Regex _open = new Regex("を開ける");

    private Regex _use = new Regex("使う");

    //決められた文字のどれかを入力させここで判定する
    //違う場合はもう一度選択文を出力したい
    public void TextInput()
    {
        if (_inputField.text != "" && !_gm._gameClear)
        {
            _tp.InputTextPrint(_inputField.text);

            switch (_inputField.text)
            {
                case "東":
                    if (_player.PlayerRoom.rooms[0] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[0]);
                    }
                    break;

                case "西":
                    if (_player.PlayerRoom.rooms[1] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[1]);
                    }
                    break;

                case "南":
                    if (_player.PlayerRoom.rooms[2] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[2]);
                    }
                    break;

                case "北":
                    if (_player.PlayerRoom.rooms[3] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[3]);
                    }
                    break;

                case "位置":
                    _tp.TextPrint(_player.PlayerRoom.name);
                    _player.RoomCenter();
                    break;

                case "アイテム":
                    if (_inventory._roomItems.Count > 0)
                    {
                        _tp.TextPrint("アイテム一覧");
                        string[] ItemNames = new string[_inventory._roomItems.Count];
                        for (int i = 0; i < _inventory._roomItems.Count; i++)
                        {
                            ItemNames[i] = _inventory._roomItems[i].itemName;
                        }
                        _tp.MessageTextSet = ItemNames;
                    }
                    else { _tp.TextPrint("所持しているアイテムはない"); }
                    break;

                case "終了":
                    Application.Quit();
                    break;
                default:
                    //ものを取ると書いた時の処理
                    if (_get.IsMatch(_inputField.text))
                    {
                        GetItem();
                    }
                    //ものを見ると書いた時の処理
                    else if (_look.IsMatch(_inputField.text))
                    {
                        LookItem();
                    }
                    //ものを開けると書いた時の処理
                    else if (_open.IsMatch(_inputField.text))
                    {
                        OpenItem();
                    }
                    //ものを使うと書いた時の処理
                    else if (_use.IsMatch(_inputField.text))
                    {
                        UseItem();
                    }
                    break;
            }
        }
        else if (_gm._gameClear) 
        {
            _tp.InputTextPrint(_inputField.text);
            if(_inputField.text == "終了") 
            {
                Application.Quit();
            }
        }
    }

    private void GetItem()
    {
        for (int i = 0; i < _player.PlayerRoom.roomItemList.Count; i++)
        {
            Regex regex = new Regex(_player.PlayerRoom.roomItemList[i].itemName);

            if (regex.IsMatch(_inputField.text))
            {
                if (TextIsMatch(_tp.MessageTextSet, regex) || TextIsMatch(_player.PlayerRoom.texts, regex))
                {
                    if (_inventory.ItemSearch(_player.PlayerRoom.roomItemList[i]))
                    {
                        RoomItem seachItem = _player.PlayerRoom.roomItemList[i];

                        if (seachItem.lifeBool && seachItem.deadBool)
                        {
                            _tp.TextPrint("意識がない少女を本ごと抱えた。");
                        }
                        else { _tp.MessageTextSet = seachItem.getText; }

                        _inputField.text = "";

                        if (seachItem.collectItemBool)
                        {
                            _inventory._roomItems.Add(seachItem);
                            if (seachItem.getItemName.Length > 0)
                            {
                                for (int j = 0; j < _player.PlayerRoom.roomItemList.Count; j++)
                                {
                                    foreach (var itemName in seachItem.getItemName)
                                    {
                                        if (_player.PlayerRoom.roomItemList[j].itemName == itemName)
                                        {
                                            _inventory._roomItems.Add(_player.PlayerRoom.roomItemList[j]);
                                            break;
                                        }
                                    }
                                }
                            }
                            _player.PlayerRoom.ItemNotSearchtexts = seachItem.notFaundText;
                        }
                    }
                    return;
                }
            }
        }
        _inputField.text = "";
        Debug.Log("取るものがありませんでした");
    }

    private void LookItem()
    {
        for (int i = 0; i < _player.PlayerRoom.roomItemList.Count; i++)
        {
            RoomItem item = _player.PlayerRoom.roomItemList[i];

            Regex regex = new Regex(item.itemName);

            if (regex.IsMatch(_inputField.text))
            {
                if (TextIsMatch(_tp.MessageTextSet, regex) || TextIsMatch(_player.PlayerRoom.texts, regex))
                {
                    if (item.lifeBool && item.deadBool)
                    {
                        _tp.MessageTextSet = _player.PlayerRoom.roomItemList[i].DiedText;
                    }
                    else { _tp.MessageTextSet = _player.PlayerRoom.roomItemList[i].informationText; }
                    _inputField.text = "";
                    return;
                }
            }
        }

        for (int i = 0; i < _inventory._roomItems.Count; i++)
        {
            RoomItem item = _inventory._roomItems[i];

            Regex regex = new Regex(item.itemName);

            if (item.lifeBool && item.deadBool)
            {
                _tp.MessageTextSet = item.DiedText;
            }
            else { _tp.MessageTextSet = item.informationText; }
            _inputField.text = "";
            return;

        }
        _inputField.text = "";
        Debug.Log("見るものがありませんでした");
    }

    private void OpenItem()
    {
        for (int i = 0; i < _player.PlayerRoom.roomItemList.Count; i++)
        {
            Regex regex = new Regex(_player.PlayerRoom.roomItemList[i].itemName);

            if (regex.IsMatch(_inputField.text))
            {
                if (TextIsMatch(_tp.MessageTextSet, regex) || TextIsMatch(_player.PlayerRoom.texts, regex))
                {
                    Regex regexDoor = new Regex("扉");

                    if (regexDoor.IsMatch(_player.PlayerRoom.roomItemList[i].itemName))
                    {
                        _tp.TextPrint("扉を開き奥の部屋に入った。");
                        RoomSet(_player.PlayerRoom.roomItemList[i].room);
                    }
                    else
                    {
                        _tp.MessageTextSet = _player.PlayerRoom.roomItemList[i].openText;
                    }
                    _inputField.text = "";
                    return;
                }
            }
        }

        for (int i = 0; i < _inventory._roomItems.Count; i++)
        {
            Regex regex = new Regex(_inventory._roomItems[i].itemName);

            if (regex.IsMatch(_inputField.text))
            {
                _tp.MessageTextSet = _inventory._roomItems[i].openText;
                _inputField.text = "";
                return;
            }
        }

        _inputField.text = "";
        Debug.Log("開けるものがありませんでした");
    }

    private void UseItem()
    {
        for (int i = 0; i < _inventory._roomItems.Count; i++)
        {
            Regex regex = new Regex("^" + _inventory._roomItems[i].itemName);

            if (regex.IsMatch(_inputField.text))
            {
                RoomItem useToItem = UseToItemSeach(_inventory._roomItems[i]);

                if (useToItem != null)
                {
                    _inputField.text = "";
                    _inventory.Use(_inventory._roomItems[i], useToItem);
                    break;
                }
            }

        }
        _inputField.text = "";
        Debug.Log("使用できません");
    }

    private bool TextIsMatch(string[] texts, Regex regex)
    {
        foreach (var text in texts)
        {
            if (regex.IsMatch(text))
            {
                return true;
            }
        }
        return false;
    }

    private RoomItem UseToItemSeach(RoomItem item)
    {
        string itemSearch = _inputField.text.Replace(item.itemName, "");

        for (int i = 0; i < _inventory._roomItems.Count; i++)
        {
            Regex regex = new Regex(_inventory._roomItems[i].itemName);

            if (regex.IsMatch(itemSearch))
            {
                return _inventory._roomItems[i];
            }
        }

        for (int i = 0; i < _player.PlayerRoom.roomItemList.Count; i++)
        {
            Regex regex = new Regex(_player.PlayerRoom.roomItemList[i].itemName);

            if (regex.IsMatch(itemSearch))
            {
                return _player.PlayerRoom.roomItemList[i];
            }
        }

        return null;
    }

    public void RoomSet(Room room)
    {
        _player.PlayerRoom = room;
    }
}
