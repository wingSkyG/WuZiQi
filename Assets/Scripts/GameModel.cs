using System;
using UnityEngine;

public class GameModel
{
    private static int _boardSize = 21;
    public PieceEnum[,] BoardMap = new PieceEnum[_boardSize, _boardSize];

    public PieceInfo AddPieceToBoardMap(Vector3 clickScreenPos)
    {
        var clickWorldPos = Utils.TransScreenPosToWorldPos(clickScreenPos);
        return CalculatePieceIndexInBoardMap(clickWorldPos);
    }
    
    public bool IsClickPlaceAreaOfBoard(Vector3 clickScreenPos, GameObject boardArea)
    {
        var worldPos = Utils.TransScreenPosToWorldPos(clickScreenPos);
        var localClickPos = boardArea.transform.InverseTransformPoint(worldPos);
        
        var bounds = boardArea.gameObject.GetComponent<SpriteRenderer>().sprite.bounds;
        Vector3 minBound = bounds.min;
        Vector3 maxBound = bounds.max;
        Vector3 center = bounds.center;
        bool isInsideBounds = localClickPos.x >= minBound.x && localClickPos.x <= maxBound.x
                                                            && localClickPos.y >= minBound.y &&
                                                            localClickPos.y <= maxBound.y;
        return isInsideBounds;
    }
    
    private PieceInfo CalculatePieceIndexInBoardMap(Vector3 clickWorldPos)
    {
        var lowerLeftCornerX = GameObject.Find("LowerLeftCorner").gameObject.transform.position.x;
        var lowerLeftCornerY = GameObject.Find("LowerLeftCorner").gameObject.transform.position.y;
        var upperRightCornerX = GameObject.Find("UpperRightCorner").gameObject.transform.position.x;
        var boardWidth = upperRightCornerX - lowerLeftCornerX;
        var boardCellSize = boardWidth / 20;
        var halfOfBoardCellSize = boardCellSize / 2;

        var indexXTemp = Mathf.Abs(clickWorldPos.x - lowerLeftCornerX) / boardCellSize;
        var indexYTemp = Mathf.Abs(clickWorldPos.y - lowerLeftCornerY) / boardCellSize;
        var indexXRemainder = Mathf.Abs(clickWorldPos.x - lowerLeftCornerX) % boardCellSize;
        var indexYRemainder = Mathf.Abs(clickWorldPos.y - lowerLeftCornerY) % boardCellSize;
        var indexX = indexXRemainder > halfOfBoardCellSize ? Mathf.CeilToInt(indexXTemp) : Mathf.FloorToInt(indexXTemp);
        var indexY = indexYRemainder > halfOfBoardCellSize ? Mathf.CeilToInt(indexYTemp) : Mathf.FloorToInt(indexYTemp);

        var clickWorldPosX = lowerLeftCornerX + indexX * boardCellSize;
        var clickWorldPosY = lowerLeftCornerY + indexY * boardCellSize;
        
        // Debug.Log($"lowerLeftCornerX:{lowerLeftCornerX}");
        // Debug.Log($"upperRightCornerX:{upperRightCornerX}");
        // Debug.Log($"boardWidth:{boardWidth}");
        // Debug.Log($"boardCellSize:{boardCellSize}");
        // Debug.Log($"halfOfBoardCellSize:{halfOfBoardCellSize}");
        // Debug.Log($"pieceWorldPos:{clickWorldPos}");
        // Debug.Log($"indexX:{indexX}, indexY:{indexY}");
        // Debug.Log($"clickWorldPosX:{clickWorldPosX}, clickWorldPosY:{clickWorldPosY}");
        
        // return new PieceInfo { IndexXInBoardMap = clickWorldPosX, IndexYInBoardMap = clickWorldPosY, PieceType = PieceEnum.BlackPiece };
        // return new PieceInfo { new Vector2(clickWorldPosX, clickWorldPosY), PieceType = PieceEnum.BlackPiece };
        return new PieceInfo(new Vector2(clickWorldPosX, clickWorldPosY), PieceEnum.BlackPiece);
    }
}