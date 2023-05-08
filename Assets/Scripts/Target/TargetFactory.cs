using System;
using UnityEngine;

public class TargetFactory : MonoBehaviour
{
    [SerializeField] private GameObject m_normalEnemyPrefab;
    [SerializeField] private TargetManager m_targetManager;

    internal NormalEnemy GetNormalEnemy()
    {
        //create a normal enemy
        GameObject normalEnemyGameObject = Instantiate(m_normalEnemyPrefab);
        NormalEnemy normalEnemy = normalEnemyGameObject.GetComponent<NormalEnemy>();
        m_targetManager.AddTarget(normalEnemy);
        return normalEnemy;
    }
}
