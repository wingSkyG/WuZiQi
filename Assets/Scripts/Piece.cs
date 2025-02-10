using System;
using Unity.VisualScripting;
using UnityEngine;

public class Piece
{
    private PieceInfo _pieceInfo;
    
    public Piece(PieceInfo pieceInfo)
    {
        _pieceInfo = pieceInfo;
        
        var asset = Resources.Load($"Prefabs/blackPiece");
        var obj = GameObject.Instantiate(asset, GameObject.Find("Pieces").gameObject.transform) as GameObject;

        obj.GameObject().transform.position = new Vector3(_pieceInfo.IndexInBoardMap.x, pieceInfo.IndexInBoardMap.y, -1);
    }
}