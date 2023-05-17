using System;
using UnityEngine;

public class TargetFactory : MonoBehaviour
{
    [SerializeField] private GameObject m_normalEnemyPrefab;
    [SerializeField] private GameObject m_allyPrefab;
    [SerializeField] private TargetManager m_targetManager;
    public static TargetSpecification m_normalEnemySpecification { get; private set; }
    public static TargetSpecification m_allySpecification { get; private set; }

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
    private void Start() 
    {
        m_normalEnemySpecification = new TargetSpecification(
            Target.Type.NormalEnemy,
            GameConfig.Instance.m_normalEnemyDuration,
            GameConfig.Instance.m_normalEnemyScore,
            GameConfig.Instance.m_normalEnemyHoldOnTime,
            GameConfig.Instance.m_normalEnemySpiritAmount
        );
        m_allySpecification = new TargetSpecification(
            Target.Type.Ally,
            GameConfig.Instance.m_allyDuration,
            GameConfig.Instance.m_allyScore,
            GameConfig.Instance.m_allyHoldOnTime,
            GameConfig.Instance.m_allySpiritAmount
        );
    }
}
