using System;
using UnityEngine;

public class GameMechanicExecutor : MonoBehaviour
{
    private float m_remainTimeForNextTarget = 0.0f;
    private float m_waitTimeForNextSpawn = 2.0f;

    [SerializeField] private TargetFactory m_targetFactory;
    [SerializeField] private HolesManager m_holesManager;
    [SerializeField] private Player m_player;
    [SerializeField] private SpiritBar m_spiritBar;

    public void SpawnTarget()
    {
#nullable enable
        Hole? hole = m_holesManager.GetRandomEmptyHole();
        if (hole == null)
        {
            // Debug.Log("No empty hole");
            return;
        }
#nullable disable 

        Target.Type type = (Target.Type)UnityEngine.Random.Range(0, Enum.GetNames(typeof(Target.Type)).Length);
        Target target = null;
        switch (type)
        {
            case Target.Type.NormalEnemy:
                target = m_targetFactory.GetNormalEnemy();
                break;
            case Target.Type.Ally:
                target = m_targetFactory.GetAlly();
                break;
            default:
                break;
        }
        target.SetHole(hole);
        target.m_onTargetHitEvent += OnTargetHit;
        m_remainTimeForNextTarget = m_waitTimeForNextSpawn;
        hole.SpawnTarget(target);
    }

    internal void UpdateInternal()
    {
        m_remainTimeForNextTarget -= Time.deltaTime;
        if (m_remainTimeForNextTarget <= 0.0f)
        {
            SpawnTarget();
        }

        m_spiritBar.InternalUpdate();
    }

    public void OnTargetHit(Target target)
    {
        if (target.m_type == Target.Type.NormalEnemy)
        {
            m_player.IncreaseScore(NormalEnemy.m_score);
            m_spiritBar.IncreaseSpirit(NormalEnemy.m_spiritAmount);
        }
        else if (target.m_type == Target.Type.Ally)
        {
            m_player.IncreaseScore(-Ally.m_score);
            m_spiritBar.IncreaseSpirit(-Ally.m_spiritAmount);
        }
    }

    private void Start() 
    {
        m_waitTimeForNextSpawn = GameConfig.Instance.m_waitTimeForNextSpawn;
    }
}
