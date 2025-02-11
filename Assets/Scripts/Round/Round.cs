using UnityEngine;

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

    public PieceBase CreatePiece(Vector2 piecePos)
    {
        return _playState.CreatePiece(this, piecePos);
    }
}