using UnityEngine;

public class GameCtrl
{
    private Map _map;
    private Round _round;
    private Judgment _judgment;
    private Board _board;

    public GameCtrl()
    {
        _map = new Map();
        _round = new Round(new BlackPlayState());
        _board = new Board();
    }
    
    public void Update()
    {
        if (_board.IsClicked())
        {
            var piece = _round.CreatePiece(_board.GetWorldCoord());
            
            _map.UpdateBoardMap(_board.GetIndexCoord(), piece);
            
            Debug.Log(_map.IsFivePiecesLinked(_board.GetIndexCoord()));
            // Debug.Log( _map.GetIndexPosOfPlacedPiece());
        }
    }
}