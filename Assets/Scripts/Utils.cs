using UnityEngine;

public static class Utils
{
    public static Vector3 TransScreenPosToWorldPos(Vector2 screenPos)
    {
        var worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Camera.main.nearClipPlane));

        return worldPos;
    }
}