using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Map
{
    private static int _boardSize = 21;
    private CrossPointStateEnum[,] _mapArray = new CrossPointStateEnum[_boardSize, _boardSize];

    private FiveSameElementsLinkedIterator _linkedIterator;

    public Map()
    {
        _linkedIterator = new FiveSameElementsLinkedIterator(_mapArray);
    }

    public bool IsFivePiecesLinked(Vector2Int indexCoord)
    {
        return _linkedIterator.IsLinked(indexCoord);
    }

    public void UpdateBoardMap(Vector2Int indexCoord, PieceBase pieceBase)
    {
        
        if (pieceBase.GetType() == typeof(BlackPiece))
        {
            _mapArray[indexCoord.x, indexCoord.y] = CrossPointStateEnum.BlackPiece;
            return;
        }
        
        if (pieceBase.GetType() == typeof(WhitePiece))
        {
            _mapArray[indexCoord.x, indexCoord.y] = CrossPointStateEnum.WhitePiece;
        }
    }

    /// <summary>
    /// 获取棋盘上棋子的坐标点（用于测试）
    /// </summary>
    /// <returns>坐标点字符串</returns>
    public string GetIndexPosOfPlacedPiece()
    {
        var indexPosOfPlacedPieceDict = new Dictionary<Vector2, CrossPointStateEnum>();
        var sb = new StringBuilder();

        for (int i = 0; i < _boardSize; i++)
        {
            for (int j = 0; j < _boardSize; j++)
            {
                
                if (_mapArray[i,j] == CrossPointStateEnum.Empty)
                {
                    continue;
                }

                indexPosOfPlacedPieceDict.Add(new Vector2(i, j), _mapArray[i, j]);
            }
        }

        foreach (var kvp in indexPosOfPlacedPieceDict)
        {
            sb.Append($"{kvp.Key} : {kvp.Value}\n");
        }
        string combinedInfo = sb.ToString();
        
        return combinedInfo;
    }
}