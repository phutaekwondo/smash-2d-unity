using UnityEngine;

public class NormalEnemy : Enemy
{

    public NormalEnemy(): base()
    {
        m_type = Target.Type.NormalEnemy;
        m_remainTime = GameConfig.Instance.m_normalEnemyHoldOnTime; 
        m_holdOnTime = GameConfig.Instance.m_normalEnemyHoldOnTime;
        m_score = GameConfig.Instance.m_noremalEnemyScore;
    }
    public override void OnHit()
    {
        base.OnHit();
        this.DrawIn();
    }
}
