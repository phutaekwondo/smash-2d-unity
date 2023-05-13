using System;
using UnityEngine;

public class TargetFactory : MonoBehaviour
{
    [SerializeField] private GameObject m_normalEnemyPrefab;
    [SerializeField] private GameObject m_allyPrefab;
    [SerializeField] private TargetManager m_targetManager;

    internal Ally GetAlly()
    {
        return SpawnTarget(m_allyPrefab).GetComponent<Ally>();
    }

    internal NormalEnemy GetNormalEnemy()
    {
        return SpawnTarget(m_normalEnemyPrefab).GetComponent<NormalEnemy>();
    }

    private Target SpawnTarget(GameObject prefab)
    {
        GameObject targetGameObject = Instantiate(prefab);
        Target target = targetGameObject.GetComponent<Target>();
        m_targetManager.AddTarget(target);
        return target;
    }
}
