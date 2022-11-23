using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

public class TextPrinter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _textUi = default;

    [SerializeField]
    private string[] _messages;

    public string[] MessageSet
    {
        set
        {
            _messages = value;
        }
    }

    private void Start()
    {
        _textUi.text = "";
        Print();
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
        }
    }
}
