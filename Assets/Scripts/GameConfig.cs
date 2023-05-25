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
    //Ally
    public float m_allyHoldOnTime { get; private set; } = 2.0f;
    public int m_allyScore { get; private set; } = 10;
    public float m_allySpiritAmount { get; private set; } = 20f;
    public int m_allyDuration { get; private set; } = 1;
    //NormalEnemy
    public float m_normalEnemyHoldOnTime { get; private set; } = 2.0f;
    public int m_normalEnemyScore { get; private set; } = 3;
    public float m_normalEnemySpiritAmount { get; private set; } = 10f;
    public int m_normalEnemyDuration { get; private set; } = 1;
    //StrongEnemy
    public float m_strongEnemyHoldOnTime { get; private set; } = 2.0f;
    public int m_strongEnemyScore { get; private set; } = 10;
    public float m_strongEnemySpiritAmount { get; private set; } = 15f;
    public int m_strongEnemyDuration { get; private set; } = 3;
    //SequencedEnemy (just for last member)
    public int m_sequencedEnemiesCount { get; private set; } = 3;
    public float m_sequencedEnemyHoldOnTime { get; private set; } = 2.0f;
    public int m_sequencedEnemyScore { get; private set; } = 10;
    public float m_sequencedEnemySpiritAmount { get; private set; } = 15f;
    public int m_sequencedEnemyDuration { get; private set; } = 1;

    //====GAME MECHANIC====
    public float m_spiritDropSpeed { get; private set; } = 20f; //per second
    public float m_waitTimeForNextSpawn { get; private set; } = 0.5f;
}
