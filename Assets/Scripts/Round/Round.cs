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

    public PieceBase CreatePiece(PieceInfo pieceInfo)
    {
        return _playState.CreatePiece(this, pieceInfo);
    }
}