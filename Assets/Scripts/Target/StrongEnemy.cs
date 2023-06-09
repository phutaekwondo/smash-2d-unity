using TMPro;
using UnityEngine;

public class StrongEnemy : Enemy
{
    [SerializeField] private TMP_Text m_HitsRemainText;

    public StrongEnemy(): base()
    {
        m_specification = TargetFactory.m_strongEnemySpecification;
        if (m_specification != null)
        {
            m_remainHitTimes = m_specification.m_hitDuration; 
            m_remainTime = m_specification.m_holdOnTime; 
        }
        else
        {
            //use magic number if cannot find specification
            m_remainHitTimes = 3;
            m_remainTime = 3;
        }
    }

    private void Start() 
    {
        m_HitsRemainText.text = m_remainHitTimes.ToString();
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

        m_HitsRemainText.text = m_remainHitTimes.ToString();
    }
}
