using System;
using System.Collections.Generic;
using UnityEngine;

public class FiveSameElementsLinkedIterator
{
    private CrossPointStateEnum[,] _iteratorArray;
    private Vector2Int[] _iteratorStarter;
    private Vector2Int[] _iteratorStep;
    private IteratorDirection[] _iteratorDirections;

    // private Vector2 _iteratorController;
    private Vector2Int[] _iteratorControllerArray;
    private Dictionary<IteratorDirection, Vector2Int[]> _iteratorControllerDic; 

    private enum IteratorDirection
    {
        Hori,
        Verti,
        LeftSlash,
        RightSlash
    }
    
    public FiveSameElementsLinkedIterator(CrossPointStateEnum[,] iteratorArray)
    {
        _iteratorArray = iteratorArray;
        
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
        
        _iteratorDirections = (IteratorDirection[])Enum.GetValues(typeof(IteratorDirection));
        _iteratorDirections = new IteratorDirection[]
        {
            IteratorDirection.Hori, IteratorDirection.Verti, IteratorDirection.LeftSlash, IteratorDirection.RightSlash
        };
        
        InitIteratorControllerDic();
    }

    public bool IsLinked(Vector2Int currentIndex)
    {
        var elementType = _iteratorArray[currentIndex.x, currentIndex.y];
        var elementNum = 0;

        foreach (var iteratorController in _iteratorControllerDic)
        {
            for (var i = 1; i <= 9; i++)
            {
                if (_iteratorArray[currentIndex.x + iteratorController.Value[0].x + iteratorController.Value[1].x * (i - 1),
                        currentIndex.y + iteratorController.Value[0].y + iteratorController.Value[1].y * (i - 1)] != elementType)
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

    private void InitIteratorControllerDic()
    {
        _iteratorControllerDic = new Dictionary<IteratorDirection, Vector2Int[]>();
        foreach (var iteratorDirection in _iteratorDirections)
        {
            switch (iteratorDirection)
            {
                case IteratorDirection.Hori:
                    _iteratorControllerArray = new Vector2Int[] { _iteratorStarter[0], _iteratorStep[0] };
                    _iteratorControllerDic.Add(_iteratorDirections[0], _iteratorControllerArray);
                    break;
                case IteratorDirection.Verti:
                    _iteratorControllerArray = new Vector2Int[] { _iteratorStarter[1], _iteratorStep[1] };
                    _iteratorControllerDic.Add(_iteratorDirections[1], _iteratorControllerArray);
                    break;
                case IteratorDirection.LeftSlash:
                    _iteratorControllerArray = new Vector2Int[] { _iteratorStarter[2], _iteratorStep[2] };
                    _iteratorControllerDic.Add(_iteratorDirections[2], _iteratorControllerArray);
                    break;
                case IteratorDirection.RightSlash:
                    _iteratorControllerArray = new Vector2Int[] { _iteratorStarter[3], _iteratorStep[3] };
                    _iteratorControllerDic.Add(_iteratorDirections[3], _iteratorControllerArray);
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