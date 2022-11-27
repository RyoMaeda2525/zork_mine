using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool _gameClear = false;

    [SerializeField]
    private RoomManager _roomManager;

    [SerializeField]
    private TextPrinter _tp;

    [SerializeField, Tooltip("�Q�[���N���A�̔���ȕ������")]
    private Room _judgeRoom;

    [SerializeField, Tooltip("�Q�[���N���A�̔���ȃA�C�e�����")]
    private string[] _judgeItemName;

    private List<RoomItem> _deadItems;

    public void Ending()
    {
        _gameClear = true;

        foreach (var item in _deadItems)
        {

            if (item.itemName == "����")
            {
                if (_deadItems.Count > 7)
                {
                    _tp.TextPrint("�����ɓ����ƁA���񂾂͂��̏������ڂ̑O�Ɍ���");
                    _tp.TextPrint("���Ȃ��Ɂu���肪�Ƃ��v�ƌ����ēV�ɗ������܂��B");
                }
                else
                {
                    _tp.TextPrint("�����ɓ����ƁA�ǂ����炩�傫�ȒQ���≅�l�̐����������Ă��܂��B");
                    _tp.TextPrint("���������b����ƐÂ��ɂȂ�A���񂾂͂��̏������ڂ̑O�Ɍ���");
                    _tp.TextPrint("���Ȃ��Ɂu���肪�Ƃ��v�ƌ����ēV�ɗ������܂��B");
                }
                _tp.TextPrint(" ���߂łƂ��������܂��I�Q�[���N���A�ł��I");
                break;
            }
            else //badEnd�m��
            {
                if (Judge(_judgeItemName[0]) && Judge(_judgeItemName[1]))
                {
                    _tp.TextPrint("�����ɓ����ƁA�����͊��������ɂ���");
                    _tp.TextPrint("�������A���̂قُ΂݂͎���ɋ��C�ɐ��܂�");
                    _tp.TextPrint("�������悤�ɏ΂��n�߂܂��B");
                    _tp.TextPrint("�u����ł悤�₭������ꂽ�B�v");
                    _tp.TextPrint("�ƌ��𓮂��������̏u�ԁA�������ɉ������o����");
                    _tp.TextPrint("���Ȃ��͂ȂԂ�E����܂����B");
                }
                else
                {
                    _tp.TextPrint("�����ɓ����ƁA�����͊��������ɂ��邪");
                    _tp.TextPrint("�i�X�Ɗ炪�c��ł����A�K���X�z����");
                    _tp.TextPrint("�u�Ȃ�ł�����͍K���Ȃ̂�v");
                    _tp.TextPrint("�ƌ��𓮂��������̏u�ԁA�������ɉ������o����");
                    _tp.TextPrint("���Ȃ��͂ȂԂ�E����܂����B");
                }
                _tp.TextPrint("BadEnd�ł��B");
                break;
            }
        }
        _tp.TextPrint("�v���C���肪�Ƃ��������܂����B");
        _tp.TextPrint("�u�I���v�Ɠ��͂��邱�ƂŃQ�[�����I���ł��܂��B");

    }

    public void DeadItemSet(RoomItem deadItem) { _deadItems.Add(deadItem); }

    private void OnApplicationQuit()
    {
        _roomManager.RoomReset();
    }

    private bool Judge(string itemName)
    {
        if (_judgeRoom != null)
        {
            for (int i = 0; i < _judgeRoom.roomItemList.Count; i++)
            {
                if (_judgeRoom.roomItemList[i].itemName == itemName)
                { return true; }
            }
            return false;
        }
        return false;
    }
}
