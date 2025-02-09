using UnityEngine;
using UnityEngine.InputSystem;

public class Ctrl
{
    private View _view = new View();
    
    public void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            var asset = Resources.Load($"Prefabs/blackPiece");
            var obj = GameObject.Instantiate(asset, GameObject.Find("Pieces").gameObject.transform) as GameObject;
            _view.DisplayPiece(obj ,TransScreenPosToWorldPos(Mouse.current.position.ReadValue()));
        }
    }
    
    private Vector3 TransScreenPosToWorldPos(Vector2 screenPos)
    {
        var worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Camera.main.nearClipPlane));

        return worldPos;
    }
}