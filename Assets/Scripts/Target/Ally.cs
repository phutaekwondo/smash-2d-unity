using UnityEngine;

public class Ally : Target
{
    public Ally(): base()
    {
        m_type = Target.Type.Ally;
        m_remainHitTimes = 1; 
        m_remainTime = GameConfig.Instance.m_allyHoldOnTime; 
        m_holdOnTime = GameConfig.Instance.m_allyHoldOnTime;
        m_score = GameConfig.Instance.m_allyScore;
        m_spiritAmount = GameConfig.Instance.m_allySpiritAmount;
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
