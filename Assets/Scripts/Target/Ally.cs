using UnityEngine;

public class Ally : Target
{
    public Ally(): base()
    {
        m_type = Target.Type.Ally;
        m_remainTime = GameConfig.Instance.m_allyHoldOnTime; 
        m_holdOnTime = GameConfig.Instance.m_allyHoldOnTime;
        m_score = GameConfig.Instance.m_allyScore;
    }

    public override void OnHit()
    {
        base.OnHit();
        this.DrawIn();
    }
}
