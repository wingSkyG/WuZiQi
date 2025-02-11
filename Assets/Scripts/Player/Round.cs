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

    public void PlacePiece(GameModel gameModel)
    {
        _playState.PlacePiece(this, gameModel);
    }
}