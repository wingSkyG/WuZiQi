using UnityEngine;

public class PieceMap
{
    private static int _boardSize = 21;
    private PieceBase[,] _mapArray = new PieceBase[_boardSize, _boardSize];
    
    public void UpdatePieceMap(Vector2Int indexCoord, PieceBase pieceBase)
    {
        _mapArray[indexCoord.x, indexCoord.y] = pieceBase;
    }
    
    public void ResetPieceMap()
    {
        for (int i = 0; i < _boardSize; i++)
        {
            for (int j = 0; j < _boardSize; j++)
            {

                if (_mapArray[i,j] == null)
                {
                    continue;
                }

                _mapArray[i, j] = null;
            }
        }
    }
}