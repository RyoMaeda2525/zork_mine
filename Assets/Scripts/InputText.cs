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
            switch (_inputField.text)
            {
                case "��":
                    if (_player.PlayerRoom.rooms[0] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[0]);
                    }
                    return;

                case "��":
                    if (_player.PlayerRoom.rooms[1] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[1]);
                    }
                    return;

                case "��":
                    if (_player.PlayerRoom.rooms[2] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[2]);
                    }
                    return;

                case "�k":
                    if (_player.PlayerRoom.rooms[3] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[3]);
                    }
                    return;

                default:
                    //���̂����Ə��������̏���
                    if (_get.IsMatch(_inputField.text))
                    {

                        for (int i = 0; i < _player.PlayerRoom.roomItemList.Count; i++)
                        {
                            Regex regex = new Regex(_player.PlayerRoom.roomItemList[i].itemName);

                            if (regex.IsMatch(_inputField.text))
                            {
                                Debug.Log($"{regex}���擾����");
                                return;
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
                                Debug.Log($"{regex}������");
                                return;
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
                                Debug.Log($"{regex}���J����");
                                return;
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
        }
    }

    public void RoomSet(Room room)
    {
        _player.PlayerRoom = room;
    }
}
