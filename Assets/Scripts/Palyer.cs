using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palyer : MonoBehaviour
{
    [SerializeField]
    TextPrinter _tp;

    public Room _playerRoom;

    private void Awake()
    {
        _tp.MessageSet = _playerRoom.text;
    }
}
