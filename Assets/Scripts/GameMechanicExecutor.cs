using System;
using UnityEngine;

public class GameMechanicExecutor : MonoBehaviour
{
    private float m_remainTimeForNextTarget = 0.0f;
    [SerializeField] private TargetFactory m_targetFactory;
    [SerializeField] private HolesManager m_holesManager;

    public void SpawnTarget()
    {
        NormalEnemy normalEnemy = m_targetFactory.GetNormalEnemy();
        m_remainTimeForNextTarget = normalEnemy.GetHoldOnTime();

        Hole hole = m_holesManager.GetRandomEmptyHole();
        hole.SpawnTarget(normalEnemy);
    }

    internal void UpdateInternal()
    {
        m_remainTimeForNextTarget -= Time.deltaTime;
        if (m_remainTimeForNextTarget <= 0.0f)
        {
            SpawnTarget();
        }
    }
}
