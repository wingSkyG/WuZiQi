using System;
using System.Text;
using TMPro;
using UnityEngine;

public class GameResultView
{
    private GameObject _gameResultCanvas;
    private TMP_Text _gameResultText;

    public GameResultView()
    {
        _gameResultCanvas = GameObject.Find("GameResultCanvas");
        _gameResultText = GameObject.Find("_gameResultText").GetComponent<TMP_Text>();
    }

    public void Open(PieceBase winner)
    {
        SetResultText(winner);
        EnableGameObject();
    }

    private void EnableGameObject()
    {
        _gameResultCanvas.SetActive(true);
    }
    
    private void SetResultText(PieceBase winner)
    {
        _gameResultText.text = "";
        
        var winnerTypeName = winner.GetType().Name;
        var winnerDisplayName = "";

        switch (winnerTypeName)
        {
            case "BlackPiece":
                winnerDisplayName = "黑方";
                break;
            case "WhitePiece":
                winnerDisplayName = "白方";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        _gameResultText.text = winnerDisplayName + "胜利";
    }
    
    public void ClearGameResult()
    {
        _gameResultText.text = "";
    }
    
    // public void DisplayGameResult(PieceBase winner)
    // {
    //     _gameResultText.text = "";
    //     
    //     var winnerTypeName = winner.GetType().Name;
    //     var winnerDisplayName = "";
    //
    //     switch (winnerTypeName)
    //     {
    //         case "BlackPiece":
    //             winnerDisplayName = "黑方";
    //             break;
    //         case "WhitePiece":
    //             winnerDisplayName = "白方";
    //             break;
    //         default:
    //             throw new ArgumentOutOfRangeException();
    //     }
    //
    //     _gameResultText.text = winnerDisplayName + "胜利";
    // }
}