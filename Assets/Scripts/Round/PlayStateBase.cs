public abstract class PlayStateBase
{
    public virtual PieceBase CreatePiece(Round round, PieceInfo pieceInfo)
    {
        return new PieceBase(pieceInfo);
    }
}