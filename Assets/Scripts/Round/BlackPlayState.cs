using UnityEngine;

/// <summary>
/// 黑棋下白棋等待状态
/// </summary>
public class BlackPlayState : PlayStateBase
{
    public override Piece CreatePiece(Round round, Vector2 piecePos)
    {
        base.CreatePiece(round, piecePos);

        var piece = PlaceBlackPiece(piecePos);
        round.ChangeState(new WhitePlayState());

        return piece;
    }

    /// <summary>
    /// 放置黑色棋子
    /// </summary>
    /// <param name="piecePos"></param>
    /// <returns></returns>
    private Piece PlaceBlackPiece(Vector2 piecePos)
    {
        var piece = new Piece(PieceColorEnum.Black, piecePos);

        return piece;
    }
}