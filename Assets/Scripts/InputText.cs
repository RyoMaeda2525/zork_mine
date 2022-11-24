using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.LowLevel;

public class InputText : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;

    [SerializeField]
    private Player _player;

    //決められた文字のどれかを入力させここで判定する
    //違う場合はもう一度選択文を出力したい
    public void TextInput() 
    {
        if (_inputField.text != "") 
        {
            switch(_inputField.text)
            {
                case "東":
                    if (_player.PlayerRoom.rooms[0] != null)
                    {
                        _player.PlayerRoom = _player.PlayerRoom.rooms[0];
                    }
                    break;

                case "西":
                    if (_player.PlayerRoom.rooms[1] != null)
                    {
                        _player.PlayerRoom = _player.PlayerRoom.rooms[1];
                    }
                    break;

                case "南":
                    if (_player.PlayerRoom.rooms[2] != null)
                    {
                        _player.PlayerRoom = _player.PlayerRoom.rooms[2];
                    }
                    break;

                case "北":
                    if (_player.PlayerRoom.rooms[3] != null) 
                    {
                        _player.PlayerRoom = _player.PlayerRoom.rooms[3];
                    }
                    break;
            }
        }
    }

    public void Select() 
    {
        _inputField.Select();
    }
}
