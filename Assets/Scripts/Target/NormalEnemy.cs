using UnityEngine;

public class NormalEnemy : Enemy
{

    public NormalEnemy(): base()
    {
        m_type = Target.Type.NormalEnemy;
        m_remainHitTimes = 1; 
        m_remainTime = GameConfig.Instance.m_normalEnemyHoldOnTime; 
        m_holdOnTime = GameConfig.Instance.m_normalEnemyHoldOnTime;
        m_score = GameConfig.Instance.m_noremalEnemyScore;
        m_spiritAmount = GameConfig.Instance.m_normalEnemySpiritAmount;
    }
    public override void OnHit()
    {
        if (m_remainHitTimes <= 0) return;

        base.OnHit();
        if (m_remainHitTimes == 0)
        {
            this.DrawIn();
        }
    }
}
