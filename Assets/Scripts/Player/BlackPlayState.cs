public class BlackPlayState : PlayStateBase
{
    public override void PlacePiece(Round round, GameModel gameModel)
    {
        base.PlacePiece(round, gameModel);

        PlaceBlackPiece(gameModel);
        
        round.ChangeState(new WhitePlayState());
    }

    public void PlaceBlackPiece(GameModel gameModel)
    {
        var coordOfCrossPoint = gameModel.CalcuteNearestCoordinateOfCrossPointOfClickPoint(Input.Instance.GetClickWorldPos());
        var pieceInfo = new PieceInfo(coordOfCrossPoint, PieceEnum.BlackPiece);
        new Piece(pieceInfo);
    }
}