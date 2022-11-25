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

    private Regex _get = new Regex("を取る");

    private Regex _look = new Regex("を見る");

    private Regex _open = new Regex("を開ける");

    private Regex _use = new Regex("を使う");

    //決められた文字のどれかを入力させここで判定する
    //違う場合はもう一度選択文を出力したい
    public void TextInput()
    {
        if (_inputField.text != "")
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


                default:
                    //ものを取ると書いた時の処理
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

                                        Debug.Log($"{regex}を取得した");
                                        _inputField.text = "";
                                        return;
                                    }
                                }
                            }
                        }
                        Debug.Log("取るものがありませんでした");
                    }
                    //ものを見ると書いた時の処理
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

                        Debug.Log("見るものがありませんでした");
                    }
                    //ものを開けると書いた時の処理
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
                                        Regex regexDoor = new Regex("扉");

                                        if (regexDoor.IsMatch(_player.PlayerRoom.roomItemList[i].itemName))
                                        {
                                            Debug.Log($"{_player.PlayerRoom.roomItemList[i].itemName}を開けた"); 
                                        }
                                        else 
                                        {
                                            Debug.Log($"{regex}を開けた");
                                        }
                                        _inputField.text = "";
                                        return;
                                    }
                                }
                            }
                        }

                        Debug.Log("開けるものがありませんでした");
                    }
                    //ものを使うと書いた時の処理
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
