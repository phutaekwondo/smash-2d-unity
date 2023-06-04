public class NormalEnemy : Enemy
{

    public NormalEnemy(): base()
    {
        m_specification = TargetFactory.m_normalEnemySpecification;
        if (m_specification != null)
        {
            m_remainHitTimes = m_specification.m_hitDuration; 
            m_remainTime = m_specification.m_holdOnTime; 
        }
    }
    public override void OnHit()
    {
        if (m_remainHitTimes <= 0) return;

        base.OnHit();
        if (m_remainHitTimes == 0)
        {
            OnSmash();
            this.DrawIn();
        }
    }
}
