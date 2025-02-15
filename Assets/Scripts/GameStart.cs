using UnityEngine;

public class GameStart : MonoBehaviour
{
    private GameCtrl _gameCtrl;
    
    void Start()
    {
        _gameCtrl = new GameCtrl();
    }
    
    void Update()
    {
        _gameCtrl.Update();
    }
}
