public class WhitePlayState : PlayStateBase
{
    public override PieceBase CreatePiece(Round round, PieceInfo pieceInfo)
    {
        base.CreatePiece(round, pieceInfo);
        
        var piece = PlaceWhitePiece(pieceInfo);
        round.ChangeState(new BlackPlayState());

        return piece;
    }

    private PieceBase PlaceWhitePiece(PieceInfo pieceInfo)
    {
        // gameModel.CalcuteCrossPointCoordAndIndexCoordOfClickPoint(Input.Instance.GetClickWorldPos());
        // var pieceInfo = new PieceInfo(gameModel.GetWorldPosOfCrossPoint(), PieceEnum.WhitePiece);
        
        var piece = new WhitePiece(pieceInfo);

        return piece;
    }
}