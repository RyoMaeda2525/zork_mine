using System;
using System.Collections;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class TextPrinter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textUi = default;

    private string[] _messages;

    [SerializeField]
    ScrollRect _sr;

    public string[] MessageSet
    {
        get { return _messages; }

        set
        {
            _messages = value;
            _textUi.text += '\n';
            Print();
        }
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

        // 1�t���[���҂��Ȃ��Ɗ��S�Ɏ��s����Ȃ�

        yield return new WaitForEndOfFrame();

        _sr.verticalNormalizedPosition = 0.0f;

    }
}
