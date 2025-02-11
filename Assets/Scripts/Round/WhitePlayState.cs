using UnityEngine;

public class WhitePlayState : PlayStateBase
{
    public override PieceBase CreatePiece(Round round, Vector2 piecePos)
    {
        base.CreatePiece(round, piecePos);
        
        var piece = PlaceWhitePiece(piecePos);
        round.ChangeState(new BlackPlayState());

        return piece;
    }

    private PieceBase PlaceWhitePiece(Vector2 piecePos)
    {
        var piece = new WhitePiece(piecePos);

        return piece;
    }
}