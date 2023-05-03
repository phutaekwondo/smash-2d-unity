using UnityEngine;

public class NormalEnemy : Enemy
{
    private void Start() 
    {
        m_remainTime = GameConfig.Instance.m_normalEnemyHoldOnTime; 
        m_holdOnTime = GameConfig.Instance.m_normalEnemyHoldOnTime;
    }
}
