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
    public float m_normalEnemyHoldOnTime { get; private set; } = 3.0f;
    public int m_noremalEnemyScore { get; private set; } = 3;
}
