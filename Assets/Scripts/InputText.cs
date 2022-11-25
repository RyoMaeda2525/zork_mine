using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.LowLevel;
using System.Text.RegularExpressions;

public class InputText : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;

    [SerializeField]
    private Player _player;

    [SerializeField]
    private TextPrinter _tp;

    private Regex _get = new Regex("�����");

    private Regex _look = new Regex("������");

    private Regex _open = new Regex("���J����");

    private Regex _use = new Regex("���g��");

    //���߂�ꂽ�����̂ǂꂩ����͂��������Ŕ��肷��
    //�Ⴄ�ꍇ�͂�����x�I�𕶂��o�͂�����
    public void TextInput()
    {
        if (_inputField.text != "")
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


                default:
                    //���̂����Ə��������̏���
                    if (_get.IsMatch(_inputField.text))
                    {
                        for (int i = 0; i < _player.PlayerRoom.roomItemList.Count; i++)
                        {
                            Regex regex = new Regex(_player.PlayerRoom.roomItemList[i].itemName);

                            if (regex.IsMatch(_inputField.text))
                            {
                                for (int j = 0; j < _tp.MessageTextSet.Length; j++)
                                {
                                    if (regex.IsMatch(_tp.MessageTextSet[j]))
                                    {

                                        Debug.Log($"{regex}���擾����");
                                        _inputField.text = "";
                                        return;
                                    }
                                }
                            }
                        }
                        Debug.Log("�����̂�����܂���ł���");
                    }
                    //���̂�����Ə��������̏���
                    else if (_look.IsMatch(_inputField.text))
                    {
                        for (int i = 0; i < _player.PlayerRoom.roomItemList.Count; i++)
                        {
                            Regex regex = new Regex(_player.PlayerRoom.roomItemList[i].itemName);

                            if (regex.IsMatch(_inputField.text))
                            {
                                for (int j = 0; j < _tp.MessageTextSet.Length; j++)
                                {
                                    if (regex.IsMatch(_tp.MessageTextSet[j]))
                                    {
                                        _tp.MessageTextSet = _player.PlayerRoom.roomItemList[i].informationText;
                                        _inputField.text = "";
                                        return;
                                    }
                                }
                            }
                        }

                        Debug.Log("������̂�����܂���ł���");
                    }
                    //���̂��J����Ə��������̏���
                    else if (_open.IsMatch(_inputField.text))
                    {
                        for (int i = 0; i < _player.PlayerRoom.roomItemList.Count; i++)
                        {
                            Regex regex = new Regex(_player.PlayerRoom.roomItemList[i].itemName);

                            if (regex.IsMatch(_inputField.text))
                            {
                                for (int j = 0; j < _tp.MessageTextSet.Length; j++)
                                {
                                    if (regex.IsMatch(_tp.MessageTextSet[0]) || regex.IsMatch(_player.PlayerRoom.texts[j]))
                                    {
                                        Regex regexDoor = new Regex("��");

                                        if (regexDoor.IsMatch(_player.PlayerRoom.roomItemList[i].itemName))
                                        {
                                            Debug.Log($"{_player.PlayerRoom.roomItemList[i].itemName}���J����"); 
                                        }
                                        else 
                                        {
                                            Debug.Log($"{regex}���J����");
                                        }
                                        _inputField.text = "";
                                        return;
                                    }
                                }
                            }
                        }

                        Debug.Log("�J������̂�����܂���ł���");
                    }
                    //���̂��g���Ə��������̏���
                    else if (_use.IsMatch(_inputField.text))
                    {

                    }
                    break;
            }
            _inputField.text = "";
        }
    }

    public void RoomSet(Room room)
    {
        _player.PlayerRoom = room;
    }
}
