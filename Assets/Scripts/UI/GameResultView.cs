using System;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameResultView
{
    // private GameObject _gameResultCanvas;
    private TMP_Text _gameResultText;

    public GameResultView()
    {
        // var gameResultCanvasPrefab = Resources.Load("Prefabs/GameResultCanvas");
        // var gameResultCanvasObj = Object.Instantiate(gameResultCanvasPrefab, GameObject.Find("UIRoot").transform);
        // gameResultCanvasObj.GameObject().SetActive(true);
        _gameResultText = GameObject.Find("_gameResultText").GetComponent<TMP_Text>();
    }

    // public void Open(PieceBase winner)
    // {
    //     DisplayResultText(winner);
    // }
    
    public void DisplayResultText(PieceBase winner)
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
}