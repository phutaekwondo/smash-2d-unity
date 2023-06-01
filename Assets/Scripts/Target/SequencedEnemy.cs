using UnityEngine;
using TMPro;

public class SequencedEnemy : Enemy
{
    [SerializeField] private TMP_Text m_orderText;
    [SerializeField] private Color m_readyToHitTextColor;
    [SerializeField] private Color m_notReadyToHitTextColor;
    private int m_order = 0;
    private bool m_isLast = false;
    private bool m_isReadyToHit = false;
    SequencedEnemy m_nextEnemy = null;

    public SequencedEnemy(): base()
    {
        m_specification = TargetFactory.m_sequencedEnemySpecification;
        m_remainHitTimes = m_specification.m_hitDuration; 
        m_remainTime = m_specification.m_holdOnTime; 
    }

    public override void OnHit()
    {
        if (!m_isReadyToHit) return;

        base.OnHit();

        if (m_isLast && m_remainHitTimes == 0) 
        {
            OnSmash();
        }
        else
        {
            m_nextEnemy.SetReadyToHit(true);
        }

        this.DrawIn();
    }

    public override void InternalUpdate()
    {
        base.InternalUpdate();
        m_orderText.text = m_order.ToString();
    }

    public void SetNextEnemy(SequencedEnemy nextEnemy)
    {
        m_nextEnemy = nextEnemy;
    }

    public void SetReadyToHit(bool isReadyToHit)
    {
        m_isReadyToHit = isReadyToHit;
        if (m_isReadyToHit)
        {
            m_orderText.color = m_readyToHitTextColor;
        }
        else
        {
            m_orderText.color = m_notReadyToHitTextColor;
        }
    }
    public void SetIsLast(bool isLast)
    {
        if (m_isLast == isLast) return;
        m_isLast = isLast;
    }

    public void SetOrder(int order)
    {
        m_order = order;
    }
}
