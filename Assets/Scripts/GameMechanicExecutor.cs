using System;
using UnityEngine;

public class GameMechanicExecutor : MonoBehaviour
{
    private float m_remainTimeForNextTarget = 0.0f;
    [SerializeField] private TargetFactory m_targetFactory;
    [SerializeField] private HolesManager m_holesManager;

    public void SpawnTarget()
    {

        //get a random empty hole
        Hole hole = m_holesManager.GetRandomEmptyHole();

        //create a normal enemy
        NormalEnemy normalEnemy = m_targetFactory.GetNormalEnemy();
        m_remainTimeForNextTarget = normalEnemy.GetHoldOnTime();

        //spawn the normal enemy in the hole
        hole.SpawnTarget(normalEnemy);
    }

    internal void UpdateInternal()
    {
        if (m_remainTimeForNextTarget <= 0.0f)
        {
            SpawnTarget();
        }
        m_remainTimeForNextTarget -= Time.deltaTime;
    }
}
