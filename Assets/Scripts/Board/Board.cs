using UnityEngine;

/// <summary>
/// 棋盘类
/// </summary>
public class Board
{
    private PlaceArea _placeArea; // 棋子放置区域
    private Grid _grid; // 棋盘网格

    public Board()
    {
        _placeArea = new PlaceArea();
        _grid = new Grid();
    }

    /// <summary>
    /// 获取网格点世界坐标
    /// </summary>
    /// <returns></returns>
    public Vector2 GetWorldCoord()
    {
        return _grid.GetWorldPosOfCrossPoint(Input.Instance.GetClickWorldPos());
    }
    
    /// <summary>
    /// 获取网格点地图坐标
    /// </summary>
    /// <returns></returns>
    public Vector2Int GetIndexCoord()
    {
        return _grid.GetIndexCoordOfCrossPoint(Input.Instance.GetClickWorldPos());
    }
    
    /// <summary>
    /// 棋盘是否被点击
    /// </summary>
    /// <returns></returns>
    public bool IsClicked()
    {
        return Input.Instance.IsMouseLeftButtonClicked() && _placeArea.IsClicked(Input.Instance.GetClickScreenPos());
    }
}