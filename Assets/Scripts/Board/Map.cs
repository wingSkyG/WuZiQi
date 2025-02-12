using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Map
{
    private static int _boardSize = 21;
    public CrossPointStateEnum[,] MapArray = new CrossPointStateEnum[_boardSize, _boardSize];

    // public bool IsFivePieceInLine()
    // {
    //     Vector2Int currentIndex = GetIndexCoordOfCrossPoint();
    //     var currentPieceType = MapData[currentIndex.x, currentIndex.y];
    //
    //     var pieceNum = 0;
    //     
    //     Debug.Log($"currentPieceType:{currentPieceType}");
    //     Debug.Log($"currentIndex:{currentIndex}");
    //     for (var i = 1; i <= 4; i++)
    //     {
    //         if (MapData[currentIndex.x - i, currentIndex.y] != currentPieceType)
    //         {
    //             pieceNum = 0;
    //             continue;
    //         }
    //         pieceNum++;
    //     }
    //     
    //     Debug.Log($"pieceNum:{pieceNum}");
    //     return pieceNum + 1 == 5;
    // }

    public void UpdateBoardMap(Vector2Int indexCoord, PieceBase pieceBase)
    {
        
        if (pieceBase.GetType() == typeof(BlackPiece))
        {
            MapArray[indexCoord.x, indexCoord.y] = CrossPointStateEnum.BlackPiece;
            return;
        }
        
        if (pieceBase.GetType() == typeof(WhitePiece))
        {
            MapArray[indexCoord.x, indexCoord.y] = CrossPointStateEnum.WhitePiece;
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
                
                if (MapArray[i,j] == CrossPointStateEnum.Empty)
                {
                    continue;
                }

                indexPosOfPlacedPieceDict.Add(new Vector2(i, j), MapArray[i, j]);
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