using Unity.VisualScripting;
using UnityEngine;

public class WhitePiece : PieceBase
{
    public WhitePiece(Vector2 piecePos) : base(piecePos)
    {
        PiecePos = piecePos;

        var prefabAsset = Resources.Load($"Prefabs/whitePiece");
        var obj = Object.Instantiate(prefabAsset, GameObject.Find("Pieces").gameObject.transform) as GameObject;
        obj.GameObject().transform.position = new Vector3(PiecePos.x, PiecePos.y, -1);
    }
}