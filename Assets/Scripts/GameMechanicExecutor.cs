using System;
using System.Collections.Generic;
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
        // Target.Type type = (Target.Type)UnityEngine.Random.Range(0, Enum.GetNames(typeof(Target.Type)).Length);
        Target.Type type = Target.Type.SequencedEnemy;

        if (type != Target.Type.SequencedEnemy)
        {
#nullable enable
            Hole? hole = m_holesManager.GetRandomEmptyHole();
            if (hole == null)
            {
                return;
            }
#nullable disable 
            Target target = null;
            switch (type)
            {
                case Target.Type.NormalEnemy:
                    target = m_targetFactory.GetNormalEnemy();
                    break;
                case Target.Type.Ally:
                    target = m_targetFactory.GetAlly();
                    break;
                case Target.Type.StrongEnemy:
                    target = m_targetFactory.GetStrongEnemy();
                    break;
                default:
                    break;
            }
            target.SetHole(hole);
            target.m_onTargetSmashEvent += OnTargetSmash;
            hole.SpawnTarget(target);
        }
        else
        {
            int sequenceLength = GameConfig.Instance.m_sequencedEnemiesCount;
            // check if enough empty holes 
#nullable enable
            List<Hole>? holes = m_holesManager.GetMultiEmptyHoles(sequenceLength);
            if (holes == null)
            {
                Debug.Log("Not enough empty holes for sequenced enemies");
                return;
            }
#nullable disable
            // spawn sequenced enemies
            List<SequencedEnemy> sequencedEnemies = m_targetFactory.GetSequencedEnemies(sequenceLength);

            for (int i = 0; i < sequenceLength; i++)
            {
                sequencedEnemies[i].SetHole(holes[i]);
                sequencedEnemies[i].m_onTargetSmashEvent += OnTargetSmash;
                holes[i].SpawnTarget(sequencedEnemies[i]);
            }
        }
    }

    internal void UpdateInternal()
    {
        m_remainTimeForNextTarget -= Time.deltaTime;
        if (m_remainTimeForNextTarget <= 0.0f)
        {
            SpawnTarget();
            m_remainTimeForNextTarget = m_waitTimeForNextSpawn;
        }

        m_spiritBar.InternalUpdate();
    }

    public bool IsGameOver()
    {
        return m_spiritBar.GetCurrentSpirit() <= 0.0f;
    }

    public void OnTargetSmash(Target target)
    {
        Target.Type targetType = target.GetSpecification().m_type;
        if (targetType == Target.Type.NormalEnemy)
        {
            m_player.IncreaseScore(target.GetSpecification().m_score);
            m_spiritBar.IncreaseSpirit(target.GetSpecification().m_spiritAmount);
        }
        else if (targetType == Target.Type.Ally)
        {
            m_player.IncreaseScore(-target.GetSpecification().m_score);
            m_spiritBar.IncreaseSpirit(-target.GetSpecification().m_spiritAmount);
        }
        else if (targetType == Target.Type.StrongEnemy)
        {
            m_player.IncreaseScore(target.GetSpecification().m_score);
            m_spiritBar.IncreaseSpirit(target.GetSpecification().m_spiritAmount);
        }
        else if (targetType == Target.Type.SequencedEnemy)
        {
            m_player.IncreaseScore(target.GetSpecification().m_score);
            m_spiritBar.IncreaseSpirit(target.GetSpecification().m_spiritAmount);
        }
    }

    private void Start() 
    {
        m_waitTimeForNextSpawn = GameConfig.Instance.m_waitTimeForNextSpawn;
    }

}
