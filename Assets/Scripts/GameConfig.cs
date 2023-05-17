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
    public float m_allySpiritAmount { get; private set; } = 20f;
    public int m_allyDuration { get; private set; } = 1;
    public float m_normalEnemyHoldOnTime { get; private set; } = 2.0f;
    public int m_normalEnemyScore { get; private set; } = 3;
    public float m_normalEnemySpiritAmount { get; private set; } = 10f;
    public int m_normalEnemyDuration { get; private set; } = 1;

    //====GAME MECHANIC====
    public float m_spiritDropSpeed { get; private set; } = 20f; //per second
    public float m_waitTimeForNextSpawn { get; private set; } = 0.5f;
}
