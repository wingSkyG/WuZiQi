using UnityEngine;

/// <summary>
/// 棋盘网格类
/// </summary>
public class Grid
{
    private float lowerLeftCornerX; // 网格左下角横坐标
    private float lowerLeftCornerY; // 网格左下角纵坐标
    private float upperRightCornerX; // 网格右上角横坐标
    private float boardWidth; // 棋盘宽度
    private float boardCellSize; // 网格大小
    private float halfOfBoardCellSize; // 网格半格大小

    public Grid()
    {
        lowerLeftCornerX = GameObject.Find("LowerLeftCorner").gameObject.transform.position.x;
        lowerLeftCornerY = GameObject.Find("LowerLeftCorner").gameObject.transform.position.y;
        upperRightCornerX = GameObject.Find("UpperRightCorner").gameObject.transform.position.x;
        boardWidth = upperRightCornerX - lowerLeftCornerX;
        boardCellSize = boardWidth / 20;
        halfOfBoardCellSize = boardCellSize / 2;
    }
    
    /// <summary>
    /// 获取离点击点最近的网格交点的世界坐标
    /// </summary>
    /// <param name="clickWorldPos"></param>
    /// <returns></returns>
    public Vector2 GetWorldPosOfCrossPoint(Vector3 clickWorldPos)
    {
        var indexCoordOfIntersection = GetIndexCoordOfCrossPoint(clickWorldPos);
        
        var _worldPosXOfCrossPoint = lowerLeftCornerX + indexCoordOfIntersection.x * boardCellSize;
        var _worldPosYOfCrossPoint = lowerLeftCornerY + indexCoordOfIntersection.y * boardCellSize;
        
        return new Vector2(_worldPosXOfCrossPoint, _worldPosYOfCrossPoint);
    } 
    
    /// <summary>
    /// 获取离点击点最近的网格交点的地图坐标
    /// </summary>
    /// <param name="clickWorldPos"></param>
    /// <returns></returns>
    public Vector2Int GetIndexCoordOfCrossPoint(Vector3 clickWorldPos)
    {
        var indexXFloat = Mathf.Abs(clickWorldPos.x - lowerLeftCornerX) / boardCellSize;
        var indexYFloat = Mathf.Abs(clickWorldPos.y - lowerLeftCornerY) / boardCellSize;
        var indexXRemainder = Mathf.Abs(clickWorldPos.x - lowerLeftCornerX) % boardCellSize;
        var indexYRemainder = Mathf.Abs(clickWorldPos.y - lowerLeftCornerY) % boardCellSize;
        
        var indexXOfCrossPoint = indexXRemainder > halfOfBoardCellSize ? Mathf.CeilToInt(indexXFloat) : Mathf.FloorToInt(indexXFloat);
        var indexYOfCrossPoint = indexYRemainder > halfOfBoardCellSize ? Mathf.CeilToInt(indexYFloat) : Mathf.FloorToInt(indexYFloat);

        return new Vector2Int(indexXOfCrossPoint, indexYOfCrossPoint);
    }
}