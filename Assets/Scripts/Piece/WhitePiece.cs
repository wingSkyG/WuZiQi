using Unity.VisualScripting;
using UnityEngine;

public class WhitePiece : PieceBase
{
    public WhitePiece(PieceInfo pieceInfo) : base(pieceInfo)
    {
        PieceInfo = pieceInfo;

        var prefabAsset = Resources.Load($"Prefabs/whitePiece");
        var obj = Object.Instantiate(prefabAsset, GameObject.Find("Pieces").gameObject.transform) as GameObject;
        obj.GameObject().transform.position = new Vector3(PieceInfo.IndexInBoardMap.x, pieceInfo.IndexInBoardMap.y, -1);
    }
}