using UnityEngine;
using UnityEngine.InputSystem;

public class GameStart : MonoBehaviour
{
    private GameCtrl _gameCtrl = new GameCtrl();
    
    void Start()
    {
        
    }
    
    void Update()
    {
        _gameCtrl.Update();
    }
}
