using UnityEngine;

public class GameManager : MonoBehaviour
{
    class GameState
    {
        //constructor
        public GameState(){}
        public void Update(){}
    }

    class GameState_Wait : GameState
    {
    }
    class GameState_Playing : GameState
    {
    }
    class GameState_Pause : GameState
    {
    }
    class GameState_GameOver : GameState
    {
    }
}
