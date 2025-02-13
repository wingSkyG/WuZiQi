using UnityEngine;
using UnityEngine.UI;

public class GameCtrl
{
    private IntersectionMap _intersectionMap;
    private PieceMap _pieceMap;
    private Round _round;
    private Board _board;
    private GameResultView _gameResultView;
    private Button _btnReset;

    public GameCtrl()
    {
        _intersectionMap = new IntersectionMap();
        _pieceMap = new PieceMap();
        _round = new Round(new BlackPlayState());
        _board = new Board();
        _gameResultView = new GameResultView();

        _btnReset = GameObject.Find("BtnReset").GetComponent<Button>();
        _btnReset.onClick.AddListener(ResetGame);
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
                _gameResultView.DisplayResultText(piece);
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