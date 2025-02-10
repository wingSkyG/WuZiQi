using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameCtrl
{
    // private Piece _piece = new Piece();
    private GameModel _gameModel = new GameModel();
    
    public void Update()
    {
        if (IsClickInsidePlaceArea())
        {
            // var piceInfo = new PieceInfo()
            var pieceInfo = _gameModel.AddPieceToBoardMap(Input.Instance.GetClickPos());
            var piece = new Piece(pieceInfo);
        }
    }

    /// <summary>
    /// 鼠标是否点击了落子区
    /// </summary>
    /// <returns></returns>
    private bool IsClickInsidePlaceArea()
    {
        return Input.Instance.IsClickMouseLeftButton() &&
               _gameModel.IsClickPlaceAreaOfBoard(Input.Instance.GetClickPos(), GameObject.Find("BoardArea"));
    }
}