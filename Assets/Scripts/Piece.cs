using System;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class Piece
{
    private PieceInfo _pieceInfo;
    
    public Piece(PieceInfo pieceInfo)
    {
        _pieceInfo = pieceInfo;
        
        // var asset = Resources.Load($"Prefabs/blackPiece");

        var prefabAsset = LoadPiecePrefab(pieceInfo.PieceType);
        
        var obj = Object.Instantiate(prefabAsset, GameObject.Find("Pieces").gameObject.transform) as GameObject;
        obj.GameObject().transform.position = new Vector3(_pieceInfo.IndexInBoardMap.x, pieceInfo.IndexInBoardMap.y, -1);
    }

    private Object LoadPiecePrefab(PieceEnum pieceType)
    {
        var piecePrefab = pieceType switch
        {
            PieceEnum.BlackPiece => Resources.Load($"Prefabs/blackPiece"),
            PieceEnum.WhitePiece => Resources.Load($"Prefabs/whitePiece"),
            _ => null
        };

        return piecePrefab;
    }
}