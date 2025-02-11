using UnityEngine;

public class PieceInfo
{
    // public float IndexXInBoardMap;
    // public float IndexYInBoardMap;
    public Vector2 IndexInBoardMap;
    public PieceEnum PieceType;

    public PieceInfo(Vector2 indexInBoardMap, PieceEnum pieceType)
    {
        IndexInBoardMap = indexInBoardMap;
        PieceType = pieceType;
    }
}