using UnityEngine;

/// <summary>
/// 游戏状态基类
/// </summary>
public abstract class PlayStateBase
{
    protected Piece Piece;
    
    public virtual Piece CreatePiece(Round round, Vector2 piecePos)
    {
        return Piece;
    }
}