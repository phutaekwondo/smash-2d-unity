using UnityEngine;

public class NormalEnemy : Enemy
{

    public NormalEnemy(): base()
    {
        m_remainTime = GameConfig.Instance.m_normalEnemyHoldOnTime; 
        m_holdOnTime = GameConfig.Instance.m_normalEnemyHoldOnTime;
    }
    public override void SetOrderInLayer(int m_layerInOrderForTarget)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = m_layerInOrderForTarget;
    }
    public override void OnHit()
    {
        base.OnHit();
        this.DrawIn();
    }
}
