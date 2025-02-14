using UnityEngine;

/// <summary>
/// 工具类
/// </summary>
public static class Utils
{
    /// <summary>
    /// 屏幕坐标2世界坐标
    /// </summary>
    /// <param name="screenPos"></param>
    /// <returns></returns>
    public static Vector3 TransScreenPosToWorldPos(Vector2 screenPos)
    {
        var worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Camera.main.nearClipPlane));

        return worldPos;
    }
}