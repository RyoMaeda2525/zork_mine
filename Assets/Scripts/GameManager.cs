using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool _gameClear = false;

    [SerializeField]
    private RoomManager _roomManager;

    [SerializeField]
    private TextPrinter _tp;

    [SerializeField, Tooltip("ゲームクリアの判定な部屋情報")]
    private Room _judgeRoom;

    [SerializeField, Tooltip("ゲームクリアの判定なアイテム情報")]
    private string[] _judgeItemName;

    private List<RoomItem> _deadItems;

    public void Ending()
    {
        _gameClear = true;

        foreach (var item in _deadItems)
        {

            if (item.itemName == "少女")
            {
                if (_deadItems.Count > 7)
                {
                    _tp.TextPrint("水槽に入れると、死んだはずの少女が目の前に現れ");
                    _tp.TextPrint("あなたに「ありがとう」と言って天に旅立ちます。");
                }
                else
                {
                    _tp.TextPrint("水槽に入れると、どこからか大きな嘆きや怨嗟の声が聞こえてきます。");
                    _tp.TextPrint("しかし数秒すると静かになり、死んだはずの少女が目の前に現れ");
                    _tp.TextPrint("あなたに「ありがとう」と言って天に旅立ちます。");
                }
                _tp.TextPrint(" おめでとうございます！ゲームクリアです！");
                break;
            }
            else //badEnd確定
            {
                if (Judge(_judgeItemName[0]) && Judge(_judgeItemName[1]))
                {
                    _tp.TextPrint("水槽に入れると、少女は嬉しそうにする");
                    _tp.TextPrint("しかし、そのほほ笑みは次第に狂気に染まり");
                    _tp.TextPrint("狂ったように笑い始めます。");
                    _tp.TextPrint("「これでようやく解放された。」");
                    _tp.TextPrint("と口を動かした次の瞬間、部屋中に怪物が出現し");
                    _tp.TextPrint("あなたはなぶり殺されました。");
                }
                else
                {
                    _tp.TextPrint("水槽に入れると、少女は嬉しそうにするが");
                    _tp.TextPrint("段々と顔が歪んでいき、ガラス越しで");
                    _tp.TextPrint("「なんであいつらは幸福なのよ」");
                    _tp.TextPrint("と口を動かした次の瞬間、部屋中に怪物が出現し");
                    _tp.TextPrint("あなたはなぶり殺されました。");
                }
                _tp.TextPrint("BadEndです。");
                break;
            }
        }
        _tp.TextPrint("プレイありがとうございました。");
        _tp.TextPrint("「終了」と入力することでゲームを終了できます。");

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
