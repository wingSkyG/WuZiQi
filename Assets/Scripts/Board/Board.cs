using UnityEngine;

public class Board
{
    private PlaceArea _placeArea;
    private Intersection _intersection;

    public Board()
    {
        _placeArea = new PlaceArea();
        _intersection = new Intersection();
    }

    public Vector2 GetWorldCoord()
    {
        return _intersection.GetWorldPosOfCrossPoint(Input.Instance.GetClickWorldPos());
    }
    
    public Vector2Int GetIndexCoord()
    {
        return _intersection.GetIndexCoordOfCrossPoint(Input.Instance.GetClickWorldPos());
    }
    
    public bool IsClicked()
    {
        return Input.Instance.IsMouseLeftButtonClicked() && _placeArea.IsClicked(Input.Instance.GetClickScreenPos());
    }
}