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

    private Regex _get = new Regex("�����");

    private Regex _look = new Regex("������");

    private Regex _open = new Regex("���J����");

    private Regex _use = new Regex("�g��");

    //���߂�ꂽ�����̂ǂꂩ����͂��������Ŕ��肷��
    //�Ⴄ�ꍇ�͂�����x�I�𕶂��o�͂�����
    public void TextInput()
    {
        if (_inputField.text != "" && !_gm._gameClear)
        {
            _tp.InputTextPrint(_inputField.text);

            switch (_inputField.text)
            {
                case "��":
                    if (_player.PlayerRoom.rooms[0] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[0]);
                    }
                    break;

                case "��":
                    if (_player.PlayerRoom.rooms[1] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[1]);
                    }
                    break;

                case "��":
                    if (_player.PlayerRoom.rooms[2] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[2]);
                    }
                    break;

                case "�k":
                    if (_player.PlayerRoom.rooms[3] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[3]);
                    }
                    break;

                case "�ʒu":
                    _tp.TextPrint(_player.PlayerRoom.name);
                    _player.RoomCenter();
                    break;

                case "�A�C�e��":
                    if (_inventory._roomItems.Count > 0)
                    {
                        _tp.TextPrint("�A�C�e���ꗗ");
                        string[] ItemNames = new string[_inventory._roomItems.Count];
                        for (int i = 0; i < _inventory._roomItems.Count; i++)
                        {
                            ItemNames[i] = _inventory._roomItems[i].itemName;
                        }
                        _tp.MessageTextSet = ItemNames;
                    }
                    else { _tp.TextPrint("�������Ă���A�C�e���͂Ȃ�"); }
                    break;

                case "�I��":
                    Application.Quit();
                    break;
                default:
                    //���̂����Ə��������̏���
                    if (_get.IsMatch(_inputField.text))
                    {
                        GetItem();
                    }
                    //���̂�����Ə��������̏���
                    else if (_look.IsMatch(_inputField.text))
                    {
                        LookItem();
                    }
                    //���̂��J����Ə��������̏���
                    else if (_open.IsMatch(_inputField.text))
                    {
                        OpenItem();
                    }
                    //���̂��g���Ə��������̏���
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
            if(_inputField.text == "�I��") 
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
                            _tp.TextPrint("�ӎ����Ȃ�������{���ƕ������B");
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
        Debug.Log("�����̂�����܂���ł���");
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
        Debug.Log("������̂�����܂���ł���");
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
                    Regex regexDoor = new Regex("��");

                    if (regexDoor.IsMatch(_player.PlayerRoom.roomItemList[i].itemName))
                    {
                        _tp.TextPrint("�����J�����̕����ɓ������B");
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
        Debug.Log("�J������̂�����܂���ł���");
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
        Debug.Log("�g�p�ł��܂���");
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
