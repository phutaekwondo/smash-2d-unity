using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameMechanicExecutor m_gameMechanicExecutor;
    public enum GameState
    {
        Waiting,
        Playing,
        Lost,
        Paused,
    }
}
