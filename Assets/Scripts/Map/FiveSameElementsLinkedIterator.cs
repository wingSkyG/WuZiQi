using System;
using System.Collections.Generic;
using UnityEngine;

public class FiveSameElementsLinkedIterator
{
    private Piece[,] _iteratorArray; // 迭代数组
    private Vector2Int[] _iteratorStarter; // 迭代起始坐标数组
    private Vector2Int[] _iteratorStep; //迭代步长
    private IteratorDirection[] _iteratorDirectionArray; // 迭代方向数组
    
    private Vector2Int[] _iteratorControllerArray; // 迭代控制器数组
    private Dictionary<IteratorDirection, Vector2Int[]> _iteratorControllerDic; // 迭代控制器字典

    /// <summary>
    /// 迭代方向枚举
    /// </summary>
    private enum IteratorDirection
    {
        Hori,
        Verti,
        LeftSlash,
        RightSlash
    }
    
    public FiveSameElementsLinkedIterator(Piece[,] iteratorArray)
    {
        _iteratorArray = iteratorArray;
        
        InitIteratorStarterArray();
        InitIteratorDirectionArray();
        InitIteratorControllerDic();
    }

    /// <summary>
    /// 五个相同元素是否相连
    /// </summary>
    /// <param name="currentIndex"></param>
    /// <returns></returns>
    public bool IsLinked(Vector2Int currentIndex)
    {
        var elementIndicator = _iteratorArray[currentIndex.x, currentIndex.y].PieceColor;
        var elementNum = 0;

        foreach (var iteratorController in _iteratorControllerDic)
        {
            for (var i = 1; i <= 9; i++)
            {
                var currentElement = _iteratorArray[
                    currentIndex.x + iteratorController.Value[0].x + iteratorController.Value[1].x * (i - 1),
                    currentIndex.y + iteratorController.Value[0].y + iteratorController.Value[1].y * (i - 1)];

                if (currentElement == null)
                {
                    elementNum = 0;
                    continue;
                }
                if (currentElement.PieceColor != elementIndicator)
                {
                    elementNum = 0;
                    continue;
                }
                
                elementNum++;
                if (elementNum == 5) return true;
            }
        }

        return false;
    }
    
    /// <summary>
    /// 更新迭代数组
    /// </summary>
    /// <param name="mapArray"></param>
    public void UpdateIteratorArray(Piece[,] mapArray)
    {
        _iteratorArray = mapArray;
    }

    /// <summary>
    /// 初始化迭代起始坐标数组
    /// </summary>
    private void InitIteratorStarterArray()
    {
        _iteratorStarter = new Vector2Int[]
        {
            new Vector2Int(-4, 0),
            new Vector2Int(0, 4),
            new Vector2Int(-4, -4),
            new Vector2Int(-4, 4)
        };

        _iteratorStep = new Vector2Int[]
        {
            new Vector2Int(1, 0),
            new Vector2Int(0, -1),
            new Vector2Int(1, 1),
            new Vector2Int(1, -1)
        };
    }
    
    /// <summary>
    /// 初始化迭代方向数组
    /// </summary>
    private void InitIteratorDirectionArray()
    {
        _iteratorDirectionArray = (IteratorDirection[])Enum.GetValues(typeof(IteratorDirection));
        _iteratorDirectionArray = new IteratorDirection[]
        {
            IteratorDirection.Hori, IteratorDirection.Verti, IteratorDirection.LeftSlash, IteratorDirection.RightSlash
        };
    }
    
    /// <summary>
    /// 初始化迭代字典
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private void InitIteratorControllerDic()
    {
        _iteratorControllerDic = new Dictionary<IteratorDirection, Vector2Int[]>();
        foreach (var iteratorDirection in _iteratorDirectionArray)
        {
            switch (iteratorDirection)
            {
                case IteratorDirection.Hori:
                    _iteratorControllerArray = new Vector2Int[] { _iteratorStarter[0], _iteratorStep[0] };
                    _iteratorControllerDic.Add(_iteratorDirectionArray[0], _iteratorControllerArray);
                    break;
                case IteratorDirection.Verti:
                    _iteratorControllerArray = new Vector2Int[] { _iteratorStarter[1], _iteratorStep[1] };
                    _iteratorControllerDic.Add(_iteratorDirectionArray[1], _iteratorControllerArray);
                    break;
                case IteratorDirection.LeftSlash:
                    _iteratorControllerArray = new Vector2Int[] { _iteratorStarter[2], _iteratorStep[2] };
                    _iteratorControllerDic.Add(_iteratorDirectionArray[2], _iteratorControllerArray);
                    break;
                case IteratorDirection.RightSlash:
                    _iteratorControllerArray = new Vector2Int[] { _iteratorStarter[3], _iteratorStep[3] };
                    _iteratorControllerDic.Add(_iteratorDirectionArray[3], _iteratorControllerArray);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        // foreach (var pair in _iteratorControllerDic)
        // {
        //     Debug.Log($"Key: {pair.Key}, Value: [{pair.Value[0]}, {pair.Value[1]}]");
        // }
    }
}