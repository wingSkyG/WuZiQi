using System;
using Unity.VisualScripting;
using UnityEngine;

public class Piece
{
    // public Piece(Vector3 clickScreenPos)
    // {
    //     var asset = Resources.Load($"Prefabs/blackPiece");
    //     var obj = GameObject.Instantiate(asset, GameObject.Find("Pieces").gameObject.transform) as GameObject;
    //     
    //     var worldPos = Utils.TransScreenPosToWorldPos(clickScreenPos);
    //     var worldIntPos = new Vector3(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y),
    //         1);
    //     // Debug.Log(worldIntPos);
    //     obj.GameObject().transform.position = worldIntPos;
    // }
    
    public Piece(Tuple<float, float, PieceEnum> pieceInfo)
    {
        var asset = Resources.Load($"Prefabs/blackPiece");
        var obj = GameObject.Instantiate(asset, GameObject.Find("Pieces").gameObject.transform) as GameObject;

        obj.GameObject().transform.position = new Vector3(pieceInfo.Item1, pieceInfo.Item2, 1);
    }
}