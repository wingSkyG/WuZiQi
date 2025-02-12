using UnityEngine;

public class Judgment
{
    private CrossPointStateEnum[,] _mapData;
    private Vector2Int _indexCoordOfCrossPoint;

    public Judgment(CrossPointStateEnum[,] mapData, Vector2Int indexCoordOfCrossPoint)
    {
        _mapData = mapData;
        _indexCoordOfCrossPoint = indexCoordOfCrossPoint;
    }
    
    public bool IsFivePieceInLine()
    {
        var currentPieceType = _mapData[_indexCoordOfCrossPoint.x, _indexCoordOfCrossPoint.y];

        var pieceNum = 0;
        
        Debug.Log($"currentPieceType:{currentPieceType}");
        Debug.Log($"currentIndex:{_indexCoordOfCrossPoint}");
        for (var i = 1; i <= 4; i++)
        {
            if (_mapData[_indexCoordOfCrossPoint.x - i, _indexCoordOfCrossPoint.y] != currentPieceType)
            {
                pieceNum = 0;
                continue;
            }
            pieceNum++;
        }
        
        Debug.Log($"pieceNum:{pieceNum}");
        return pieceNum + 1 == 5;
    }
}