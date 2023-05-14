using UnityEngine;

public class GameConfig : MonoBehaviour
{

    //Singleton
    public static GameConfig Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }

    //Configs
    //====TARGETS====
    public float m_allyHoldOnTime { get; private set; } = 2.0f;
    public int m_allyScore { get; private set; } = 10;
    public float m_normalEnemyHoldOnTime { get; private set; } = 2.0f;
    public int m_noremalEnemyScore { get; private set; } = 3;

    //====GAME MECHANIC====
    public float m_waitTimeForNextSpawn { get; private set; } = 0.5f;
}
