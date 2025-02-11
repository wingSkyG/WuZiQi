using System;
using UnityEngine;

public class GameModel
{
    private static int _boardSize = 21;
    public PieceEnum[,] BoardMap = new PieceEnum[_boardSize, _boardSize];

    private float lowerLeftCornerX;
    private float lowerLeftCornerY;
    private float upperRightCornerX;
    private float boardWidth;
    private float boardCellSize;
    private float halfOfBoardCellSize;

    private float _worldPosXOfCrossPoint;
    private float _worldPosYOfCrossPoint;
    private int _indexXOfCrossPoint;
    private int _indexYOfCrossPoint;

    public GameModel()
    {
        InitBoardData();
    }

    private void InitBoardData()
    {
        lowerLeftCornerX = GameObject.Find("LowerLeftCorner").gameObject.transform.position.x;
        lowerLeftCornerY = GameObject.Find("LowerLeftCorner").gameObject.transform.position.y;
        upperRightCornerX = GameObject.Find("UpperRightCorner").gameObject.transform.position.x;
        boardWidth = upperRightCornerX - lowerLeftCornerX;
        boardCellSize = boardWidth / 20;
        halfOfBoardCellSize = boardCellSize / 2;
    }

    public void UpdateBoardMap(PieceBase pieceBase)
    {
        BoardMap[_indexXOfCrossPoint, _indexYOfCrossPoint] = pieceBase.PieceInfo.PieceType;
    }

    public Vector2 GetIndexCoordOfCrossPoint()
    {
        return new Vector2(_indexXOfCrossPoint, _indexYOfCrossPoint);
    }

    public Vector2 GetWorldPosOfCrossPoint()
    {
        return new Vector2(_worldPosXOfCrossPoint, _worldPosYOfCrossPoint);
    }
    
    /// <summary>
    /// 计算距离点击点最近的网格交叉点的世界坐标和地图坐标
    /// </summary>
    /// <returns></returns>
    public void CalcuteCrossPointCoordAndIndexCoordOfClickPoint(Vector3 clickWorldPos)
    {
        var indexXInt = Mathf.Abs(clickWorldPos.x - lowerLeftCornerX) / boardCellSize;
        var indexYInt = Mathf.Abs(clickWorldPos.y - lowerLeftCornerY) / boardCellSize;
        var indexXRemainder = Mathf.Abs(clickWorldPos.x - lowerLeftCornerX) % boardCellSize;
        var indexYRemainder = Mathf.Abs(clickWorldPos.y - lowerLeftCornerY) % boardCellSize;
        
        _indexXOfCrossPoint = indexXRemainder > halfOfBoardCellSize ? Mathf.CeilToInt(indexXInt) : Mathf.FloorToInt(indexXInt);
        _indexYOfCrossPoint = indexYRemainder > halfOfBoardCellSize ? Mathf.CeilToInt(indexYInt) : Mathf.FloorToInt(indexYInt);

        _worldPosXOfCrossPoint = lowerLeftCornerX + _indexXOfCrossPoint * boardCellSize;
        _worldPosYOfCrossPoint = lowerLeftCornerY + _indexYOfCrossPoint * boardCellSize;
        
        // Debug.Log($"lowerLeftCornerX:{lowerLeftCornerX}");
        // Debug.Log($"upperRightCornerX:{upperRightCornerX}");
        // Debug.Log($"boardWidth:{boardWidth}");
        // Debug.Log($"boardCellSize:{boardCellSize}");
        // Debug.Log($"halfOfBoardCellSize:{halfOfBoardCellSize}");
        // Debug.Log($"pieceWorldPos:{clickWorldPos}");
        // Debug.Log($"indexX:{indexX}, indexY:{indexY}");
        // Debug.Log($"crossPointWorldPosX:{crossPointWorldPosX}, crossPointWorldPosY:{crossPointWorldPosY}");
    }

    /// <summary>
    /// 点击是否发生在棋盘落子区
    /// </summary>
    /// <param name="clickScreenPos"></param>
    /// <param name="boardArea"></param>
    /// <returns></returns>
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