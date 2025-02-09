using UnityEngine;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            var asset = Resources.Load($"Prefabs/blackPiece");
            Instantiate(asset, GameObject.Find("Pieces").gameObject.transform);
        }
    }
}
