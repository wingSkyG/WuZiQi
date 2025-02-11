public class WhitePlayState : PlayStateBase
{
    public override void PlacePiece(Round round, GameModel gameModel)
    {
        base.PlacePiece(round, gameModel);
        
        PlaceWhitePiece(gameModel);
        
        round.ChangeState(new BlackPlayState());
    }

    private void PlaceWhitePiece(GameModel gameModel)
    {
        var coordOfCrossPoint = gameModel.CalcuteNearestCoordinateOfCrossPointOfClickPoint(Input.Instance.GetClickWorldPos());
        var pieceInfo = new PieceInfo(coordOfCrossPoint, PieceEnum.WhitePiece);
        new Piece(pieceInfo);
    }
}