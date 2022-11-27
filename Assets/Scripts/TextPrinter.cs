using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public void CenterRoomText(string[] messages) 
    {
        if (messages != null)
        {
            foreach (var message in messages)
            {
                _textUi.text += message;
                _textUi.text += '\n';
            }
            StartCoroutine(ForceScrollDown());
        }
    }

    public void InputTextPrint(string inputText) 
    {
        _textUi.text += '\n';
        _textUi.text += ">" + inputText;
        _textUi.text += '\n';
        StartCoroutine(ForceScrollDown());
    }

    public void TextPrint(string text) 
    {
        _textUi.text += text;
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
