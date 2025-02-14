using UnityEngine;

/// <summary>
/// 白棋下黑棋等待状态
/// </summary>
public class WhitePlayState : PlayStateBase
{
    public override Piece CreatePiece(Round round, Vector2 piecePos)
    {
        base.CreatePiece(round, piecePos);
        
        var piece = PlaceWhitePiece(piecePos);
        round.ChangeState(new BlackPlayState());

        return piece;
    }

    /// <summary>
    /// 放置白色棋子
    /// </summary>
    /// <param name="piecePos"></param>
    /// <returns></returns>
    private Piece PlaceWhitePiece(Vector2 piecePos)
    {
        var piece = new Piece(PieceColorEnum.White, piecePos);

        return piece;
    }
}