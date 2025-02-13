using UnityEngine;

public class GameCtrl
{
    private IntersectionMap _intersectionMap;
    private PieceMap _pieceMap;
    private Round _round;
    private Board _board;
    private GameResultView _gameResultView;

    public GameCtrl()
    {
        _intersectionMap = new IntersectionMap();
        _pieceMap = new PieceMap();
        _round = new Round(new BlackPlayState());
        _board = new Board();
        _gameResultView = new GameResultView();
    }
    
    public void Update()
    {
        if (_board.IsClicked())
        {
            var piece = _round.CreatePiece(_board.GetWorldCoord());
            
            _intersectionMap.UpdateBoardMap(_board.GetIndexCoord(), piece);
            _pieceMap.UpdatePieceMap(_board.GetIndexCoord(), piece);

            if (_intersectionMap.IsFivePiecesLinked(_board.GetIndexCoord()))
            {
                _gameResultView.Open(piece);
                // ResetGame();
            }
            
            // Debug.Log(_map.IsFivePiecesLinked(_board.GetIndexCoord()));
        }
    }

    private void ResetGame()
    {
        _intersectionMap.ResetBoardMap();
        _pieceMap.ResetPieceMap();
        _gameResultView.ClearGameResult();
    }
}