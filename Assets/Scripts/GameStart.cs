using UnityEngine;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{
    private Ctrl _ctrl = new Ctrl();
    
    void Start()
    {
        
    }
    
    void Update()
    {
        _ctrl.Update();
    }
}
