﻿using UnityEngine;
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

    public Vector2 GetClickWorldPos()
    {
        var clickScreenPos = GetClickScreenPos();
        var clickWorldPos = Utils.TransScreenPosToWorldPos(clickScreenPos);
        
        return clickWorldPos;
    }
    
    public Vector2 GetClickScreenPos()
    {
        return Mouse.current.position.ReadValue();
    }

    public bool IsClickMouseLeftButton()
    {
        return Mouse.current.leftButton.wasPressedThisFrame;
    }
}