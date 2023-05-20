using TMPro;
using UnityEngine;

public class StrongEnemy : Enemy
{
    [SerializeField] private TMP_Text m_HitsRemainText;

    public StrongEnemy(): base()
    {
        m_specification = TargetFactory.m_strongEnemySpecification;
        m_remainHitTimes = m_specification.m_hitDuration; 
        m_remainTime = m_specification.m_holdOnTime; 
    }

    public override void InternalUpdate()
    {
        base.InternalUpdate();
        m_HitsRemainText.text = m_remainHitTimes.ToString();
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
