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
            switch (_inputField.text)
            {
                case "東":
                    if (_player.PlayerRoom.rooms[0] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[0]);
                    }
                    return;

                case "西":
                    if (_player.PlayerRoom.rooms[1] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[1]);
                    }
                    return;

                case "南":
                    if (_player.PlayerRoom.rooms[2] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[2]);
                    }
                    return;

                case "北":
                    if (_player.PlayerRoom.rooms[3] != null)
                    {
                        RoomSet(_player.PlayerRoom.rooms[3]);
                    }
                    return;

                default:
                    //ものを取ると書いた時の処理
                    if (_get.IsMatch(_inputField.text))
                    {

                        for (int i = 0; i < _player.PlayerRoom.roomItemList.Count; i++)
                        {
                            Regex regex = new Regex(_player.PlayerRoom.roomItemList[i].itemName);

                            if (regex.IsMatch(_inputField.text))
                            {
                                Debug.Log($"{regex}を取得した");
                                return;
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
                                Debug.Log($"{regex}を見た");
                                return;
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
                                Debug.Log($"{regex}を開けた");
                                return;
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
        }
    }

    public void RoomSet(Room room)
    {
        _player.PlayerRoom = room;
    }
}
