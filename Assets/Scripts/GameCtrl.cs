using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 游戏控制类
/// </summary>
public class GameCtrl
{
    private BoardMap _boardMap;
    private Round _round;
    private Board _board;
    private GameResultView _gameResultView;
    private Button _btnReset;

    public GameCtrl()
    {
        _boardMap = new BoardMap();
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
            if(!_boardMap.IsElementEmpty(_board.GetIndexCoord())) return; // 棋盘上已有棋子，则返回
            
            var piece = _round.CreatePiece(_board.GetWorldCoord());
            _boardMap.UpdateBoardMap(_board.GetIndexCoord(), piece);
            if (_boardMap.IsFivePiecesLinked(_board.GetIndexCoord()))
            {
                _gameResultView.DisplayResultText(piece);
            }
            
            // Debug.Log(_boardMap.GetIndexPosOfPlacedPiece());
            // Debug.Log(_boardMap.IsFivePiecesLinked(_board.GetIndexCoord()));
        }
    }

    private void ResetGame()
    {
        _boardMap.ResetBoardMap();
        _gameResultView.ClearGameResult();
    }
}