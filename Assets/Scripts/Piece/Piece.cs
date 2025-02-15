using System;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// 棋子类
/// </summary>
public class Piece
{
    // private GameObject _prefab;
    public PieceColorEnum PieceColor;
    // private Vector2 _position;
    private GameObject _obj;
    
    public Piece(PieceColorEnum pieceColor, Vector2 position)
    {
        PieceColor = pieceColor;
        // _position = position;
        
        // 根据棋子颜色枚举实例化棋子
        switch (PieceColor)
        {
            case PieceColorEnum.Black:
                _obj = Object.Instantiate(Resources.Load("Prefabs/blackPiece"), GameObject.Find("Pieces").gameObject.transform) as GameObject;
                break;
            case PieceColorEnum.White:
                _obj = Object.Instantiate(Resources.Load("Prefabs/whitePiece"), GameObject.Find("Pieces").gameObject.transform) as GameObject;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(pieceColor), pieceColor, null);
        }
        _obj.transform.position = new Vector3(position.x, position.y, -1);
    }

    /// <summary>
    /// 销毁棋子
    /// </summary>
    public void Destroy()
    {
        GameObject.Destroy(_obj.gameObject);
    }
}