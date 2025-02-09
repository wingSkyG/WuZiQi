using UnityEngine;
using UnityEngine.InputSystem;

public class Input
{
    private static Input _input;

    public static Input Instance
    {
        get
        {
            if (_input == null)
            {
                _input = new Input();
                return _input;
            }

            return _input;
        }
    }

    private Input() { }

    public bool IsClickMouseLeftButton()
    {
        return Mouse.current.leftButton.wasPressedThisFrame;
    }

    public Vector2 GetClickPos()
    {
        return Mouse.current.position.ReadValue();
    }
}