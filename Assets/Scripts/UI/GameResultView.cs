using System;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// 游戏结果界面
/// </summary>
public class GameResultView
{
    private TMP_Text _gameResultText;

    public GameResultView()
    {
        _gameResultText = GameObject.Find("_gameResultText").GetComponent<TMP_Text>();
    }
    
    /// <summary>
    /// 显示胜利结果
    /// </summary>
    /// <param name="winner"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void DisplayResultText(Piece winner)
    {
        _gameResultText.text = "";
        
        var winnerColor = winner.PieceColor;
        var winnerDisplayName = "";

        switch (winnerColor)
        {
            case PieceColorEnum.Black:
                winnerDisplayName = "黑方";
                break;
            case PieceColorEnum.White:
                winnerDisplayName = "白方";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        _gameResultText.text = winnerDisplayName + "胜利";
    }
    
    /// <summary>
    /// 清除游戏结果
    /// </summary>
    public void ClearGameResult()
    {
        _gameResultText.text = "";
    }
}