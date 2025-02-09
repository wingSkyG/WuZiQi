using Unity.VisualScripting;
using UnityEngine;

public class View
{
    public void DisplayPiece(GameObject obj ,Vector3 pos)
    {
        obj.GameObject().transform.position = pos;
    }
}