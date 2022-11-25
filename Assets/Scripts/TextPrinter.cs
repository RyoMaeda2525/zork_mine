using System;
using System.Collections;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputRemoting;

public class TextPrinter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textUi = default;

    private string[] _messages;

    [SerializeField]
    ScrollRect _sr;

    public string[] MessageTextSet
    {
        get { return _messages; }

        set
        {
            _messages = value;
            Print();
        }
    }

    public void InputTextPrint(string inputText) 
    {
        _textUi.text += '\n';
        _textUi.text += ">" + inputText;
        _textUi.text += '\n';
        StartCoroutine(ForceScrollDown());
    }

    public void Print()
    {
        if (_messages != null)
        {
            foreach (var message in _messages)
            {
                _textUi.text += message;
                _textUi.text += '\n';
            }
            StartCoroutine(ForceScrollDown());
        }
    }

    IEnumerator ForceScrollDown()
    {

        // 1フレーム待たないと完全に実行されない

        yield return new WaitForEndOfFrame();

        _sr.verticalNormalizedPosition = 0.0f;

    }
}
