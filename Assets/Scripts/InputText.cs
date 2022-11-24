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

    //Œˆ‚ß‚ç‚ê‚½•¶š‚Ì‚Ç‚ê‚©‚ğ“ü—Í‚³‚¹‚±‚±‚Å”»’è‚·‚é
    //ˆá‚¤ê‡‚Í‚à‚¤ˆê“x‘I‘ğ•¶‚ğo—Í‚µ‚½‚¢
    public void TextInput() 
    {
        if (_inputField.text != "") 
        {
            switch(_inputField.text)
            {
                case "“Œ":
                    if (_player.PlayerRoom.rooms[0] != null)
                    {
                        _player.PlayerRoom = _player.PlayerRoom.rooms[0];
                    }
                    break;

                case "¼":
                    if (_player.PlayerRoom.rooms[1] != null)
                    {
                        _player.PlayerRoom = _player.PlayerRoom.rooms[1];
                    }
                    break;

                case "“ì":
                    if (_player.PlayerRoom.rooms[2] != null)
                    {
                        _player.PlayerRoom = _player.PlayerRoom.rooms[2];
                    }
                    break;

                case "–k":
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
