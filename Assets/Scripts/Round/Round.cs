using UnityEngine;

/// <summary>
/// 游戏轮次类（白棋黑棋各落一子为一轮）
/// </summary>
public class Round
{
    private PlayStateBase _playState;

    public Round(PlayStateBase playStateBase)
    {
        _playState = playStateBase;
    }

    public void ChangeState(PlayStateBase playState)
    {
        _playState = playState;
    }

    public Piece CreatePiece(Vector2 piecePos)
    {
        return _playState.CreatePiece(this, piecePos);
    }
}