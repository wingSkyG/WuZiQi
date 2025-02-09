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
        if (Input.Instance.IsClickMouseLeftButton() && _gameModel.IsClickInsideBoard(Input.Instance.GetClickPos(), GameObject.Find("BoardArea")))
        {
            var pieceInfo = _gameModel.AddPiece(Input.Instance.GetClickPos());
            new Piece(pieceInfo);
        }
    }
}