public class BlackPlayState : PlayStateBase
{
    public override PieceBase CreatePiece(Round round, PieceInfo pieceInfo)
    {
        base.CreatePiece(round, pieceInfo);

        var piece = PlaceBlackPiece(pieceInfo);
        round.ChangeState(new WhitePlayState());

        return piece;
    }

    public PieceBase PlaceBlackPiece(PieceInfo pieceInfo)
    {
        // var pieceInfo = new PieceInfo(gameModel.GetWorldPosOfCrossPoint(), PieceEnum.BlackPiece);
        // var piece = new Piece(pieceInfo);

        // var piece = new Piece(pieceInfo);
        var piece = new BlackPiece(pieceInfo);

        return piece;
    }
}