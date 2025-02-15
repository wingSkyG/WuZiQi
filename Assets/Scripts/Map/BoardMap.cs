using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// 游戏地图
/// </summary>
public class BoardMap
{
    private static int _boardSize = 21;
    private Piece[,] _mapArray = new Piece[_boardSize, _boardSize];

    private FiveSameElementsLinkedIterator _linkedIterator; // 判断五个相同元素相连迭代器

    public BoardMap()
    {
        _linkedIterator = new FiveSameElementsLinkedIterator(_mapArray);
    }

    /// <summary>
    /// 游戏地图某个元素是否为空
    /// </summary>
    /// <param name="elementIndex"></param>
    /// <returns></returns>
    public bool IsElementEmpty(Vector2Int elementIndex)
    {
        return _mapArray[elementIndex.x, elementIndex.y] == null;
    }
    
    /// <summary>
    /// 判断五子是否相连
    /// </summary>
    /// <param name="indexCoord"></param>
    /// <returns></returns>
    public bool IsFivePiecesLinked(Vector2Int indexCoord)
    {
        return _linkedIterator.IsLinked(indexCoord);
    }

    /// <summary>
    /// 更新棋盘地图
    /// </summary>
    /// <param name="indexCoord"></param>
    /// <param name="piece"></param>
    public void UpdateBoardMap(Vector2Int indexCoord, Piece piece)
    {
        _mapArray[indexCoord.x, indexCoord.y] = piece;
    }

    /// <summary>
    /// 清空棋盘地图
    /// </summary>
    public void ResetBoardMap()
    {
        for (int i = 0; i < _boardSize; i++)
        {
            for (int j = 0; j < _boardSize; j++)
            {

                if (_mapArray[i,j] == null)
                {
                    continue;
                }
                
                _mapArray[i, j].Destroy();
                _mapArray[i, j] = null;
            }
        }

        _linkedIterator.UpdateIteratorArray(_mapArray);
    }

    /// <summary>
    /// 获取棋盘上棋子的坐标点（用于测试）
    /// </summary>
    /// <returns>坐标点字符串</returns>
    public string GetIndexPosOfPlacedPiece()
    {
        var indexPosOfPlacedPieceDict = new Dictionary<Vector2, Piece>();
        var sb = new StringBuilder();

        for (int i = 0; i < _boardSize; i++)
        {
            for (int j = 0; j < _boardSize; j++)
            {
                
                if (_mapArray[i,j] == null)
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