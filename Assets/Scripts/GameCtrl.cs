using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameCtrl
{
    private GameModel _gameModel;
    private Round _round;

    public GameCtrl()
    {
        _gameModel = new GameModel();
        _round = new Round(new BlackPlayState());
    }
    
    public void Update()
    {
        if (IsClickInsidePlaceArea())
        {
            _gameModel.CalcuteCrossPointCoordAndIndexCoordOfClickPoint(Input.Instance.GetClickWorldPos());
            
            var piece = _round.CreatePiece(_gameModel.GetWorldPosOfCrossPoint());
            
            _gameModel.UpdateBoardMap(piece);
            
            Debug.Log( _gameModel.GetIndexPosOfPlacedPiece());
        }
    }

    /// <summary>
    /// 鼠标是否点击了落子区
    /// </summary>
    /// <returns></returns>
    private bool IsClickInsidePlaceArea()
    {
        return Input.Instance.IsClickMouseLeftButton() &&
               _gameModel.IsClickPlaceAreaOfBoard(Input.Instance.GetClickScreenPos(), GameObject.Find("BoardArea"));
    }
}