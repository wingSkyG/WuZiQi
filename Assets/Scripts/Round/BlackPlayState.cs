using UnityEngine;

public class BlackPlayState : PlayStateBase
{
    public override PieceBase CreatePiece(Round round, Vector2 piecePos)
    {
        base.CreatePiece(round, piecePos);

        var piece = PlaceBlackPiece(piecePos);
        round.ChangeState(new WhitePlayState());

        return piece;
    }

    public PieceBase PlaceBlackPiece(Vector2 piecePos)
    {
        var piece = new BlackPiece(piecePos);

        return piece;
    }
}