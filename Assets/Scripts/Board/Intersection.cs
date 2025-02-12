using UnityEngine;

public class Intersection
{
    private float lowerLeftCornerX;
    private float lowerLeftCornerY;
    private float upperRightCornerX;
    private float boardWidth;
    private float boardCellSize;
    private float halfOfBoardCellSize;

    public Intersection()
    {
        lowerLeftCornerX = GameObject.Find("LowerLeftCorner").gameObject.transform.position.x;
        lowerLeftCornerY = GameObject.Find("LowerLeftCorner").gameObject.transform.position.y;
        upperRightCornerX = GameObject.Find("UpperRightCorner").gameObject.transform.position.x;
        boardWidth = upperRightCornerX - lowerLeftCornerX;
        boardCellSize = boardWidth / 20;
        halfOfBoardCellSize = boardCellSize / 2;
    }
    
    public Vector2 GetWorldPosOfCrossPoint(Vector3 clickWorldPos)
    {
        var indexCoordOfIntersection = GetIndexCoordOfCrossPoint(clickWorldPos);
        
        var _worldPosXOfCrossPoint = lowerLeftCornerX + indexCoordOfIntersection.x * boardCellSize;
        var _worldPosYOfCrossPoint = lowerLeftCornerY + indexCoordOfIntersection.y * boardCellSize;
        
        return new Vector2(_worldPosXOfCrossPoint, _worldPosYOfCrossPoint);
    } 
    
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