public class Ally : Target
{
    public Ally(): base()
    {
        m_specification = TargetFactory.m_allySpecification;
        m_remainHitTimes = m_specification.m_hitDuration; 
        m_remainTime = m_specification.m_holdOnTime;
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
