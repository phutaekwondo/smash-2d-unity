using System;
using System.Collections.Generic;
using UnityEngine;

public class TargetFactory : MonoBehaviour
{
    [SerializeField] private GameObject m_normalEnemyPrefab;
    [SerializeField] private GameObject m_strongEnemyPrefab;
    [SerializeField] private GameObject m_allyPrefab;
    [SerializeField] private GameObject m_sequencedEnemyPrefab;
    [SerializeField] private TargetManager m_targetManager;
    [SerializeField] private VFXExecutor m_vfxExecutor;

    public static TargetSpecification m_normalEnemySpecification { get; private set; }
    public static TargetSpecification m_allySpecification { get; private set; }
    public static TargetSpecification m_strongEnemySpecification { get; private set; }
    public static TargetSpecification m_sequencedEnemySpecification { get; private set; }

    internal Ally GetAlly()
    {
        return SpawnTarget(m_allyPrefab).GetComponent<Ally>();
    }

    internal NormalEnemy GetNormalEnemy()
    {
        return SpawnTarget(m_normalEnemyPrefab).GetComponent<NormalEnemy>();
    }

    internal List<SequencedEnemy> GetSequencedEnemies(int sequenceLength)
    {
        List<SequencedEnemy> sequencedEnemies = new List<SequencedEnemy>();
        for (int i = 0; i < sequenceLength; i++)
        {
            SequencedEnemy sequencedEnemy = SpawnTarget(m_sequencedEnemyPrefab).GetComponent<SequencedEnemy>();
            sequencedEnemy.SetOrder(i+1);
            sequencedEnemy.SetReadyToHit(false);
            sequencedEnemies.Add(sequencedEnemy);
        }
        for (int i = 0; i < sequenceLength-1; i++)
        {
            sequencedEnemies[i].SetNextEnemy(sequencedEnemies[i + 1]);
        }

        // set first enemy
        sequencedEnemies[0].SetReadyToHit(true);
        // set last enemy
        sequencedEnemies[sequencedEnemies.Count-1].SetIsLast(true);

        return sequencedEnemies;
    }

    internal StrongEnemy GetStrongEnemy()
    {
        return SpawnTarget(m_strongEnemyPrefab).GetComponent<StrongEnemy>();
    }


    private Target SpawnTarget(GameObject prefab)
    {
        GameObject targetGameObject = Instantiate(prefab);
        Target target = targetGameObject.GetComponent<Target>();
        target.m_onTargetHitEvent += m_vfxExecutor.HandleOnTargetHit;
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
        m_strongEnemySpecification = new TargetSpecification(
            Target.Type.StrongEnemy,
            GameConfig.Instance.m_strongEnemyDuration,
            GameConfig.Instance.m_strongEnemyScore,
            GameConfig.Instance.m_strongEnemyHoldOnTime,
            GameConfig.Instance.m_strongEnemySpiritAmount
        );
        m_sequencedEnemySpecification = new TargetSpecification(
            Target.Type.SequencedEnemy,
            GameConfig.Instance.m_sequencedEnemyDuration,
            GameConfig.Instance.m_sequencedEnemyScore,
            GameConfig.Instance.m_sequencedEnemyHoldOnTime,
            GameConfig.Instance.m_sequencedEnemySpiritAmount
        );
    }
}
