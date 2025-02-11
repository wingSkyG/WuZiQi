using Unity.VisualScripting;
using UnityEngine;

public class BlackPiece : PieceBase
{
    public BlackPiece(PieceInfo pieceInfo) : base(pieceInfo)
    {
        PieceInfo = pieceInfo;

        var prefabAsset = Resources.Load($"Prefabs/blackPiece");
        var obj = Object.Instantiate(prefabAsset, GameObject.Find("Pieces").gameObject.transform) as GameObject;
        obj.GameObject().transform.position = new Vector3(PieceInfo.IndexInBoardMap.x, pieceInfo.IndexInBoardMap.y, -1);
    }
}