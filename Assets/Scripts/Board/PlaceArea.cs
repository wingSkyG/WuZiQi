using UnityEngine;

/// <summary>
/// 棋盘落子区域类
/// </summary>
public class PlaceArea
{
    private GameObject _boardArea;

    public PlaceArea()
    {
        _boardArea = GameObject.Find("BoardArea");
    }
    
    /// <summary>
    /// 点击是否发生在棋盘的落子区域
    /// </summary>
    /// <param name="clickScreenPos"></param>
    /// <param name="boardArea"></param>
    /// <returns></returns>
    public bool IsClicked(Vector3 clickScreenPos)
    {
        var worldPos = Utils.TransScreenPosToWorldPos(clickScreenPos);
        var localClickPos = _boardArea.transform.InverseTransformPoint(worldPos);
        
        var bounds = _boardArea.gameObject.GetComponent<SpriteRenderer>().sprite.bounds;
        Vector3 minBound = bounds.min;
        Vector3 maxBound = bounds.max;
        Vector3 center = bounds.center;
        bool isInsideBounds = localClickPos.x >= minBound.x && localClickPos.x <= maxBound.x
                                                            && localClickPos.y >= minBound.y &&
                                                            localClickPos.y <= maxBound.y;
        return isInsideBounds;
    }
}