using UnityEngine;

public abstract class PlayStateBase
{
    public virtual PieceBase CreatePiece(Round round, Vector2 piecePos)
    {
        return new PieceBase(piecePos);
    }
}