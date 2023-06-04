using UnityEngine;
using System.Collections.Generic;

public class TutorialDirector : MonoBehaviour
{
    [SerializeField] private TargetFactory m_targetFactory;

    [SerializeField] private Hole m_normalEnemyHole;
    [SerializeField] private TutorialCursor m_normalEnemyCursor;

    [SerializeField] private Hole m_strongEnemyHole;
    [SerializeField] private TutorialCursor m_strongEnemyCursor;

    [SerializeField] private List<Hole> m_sequencedEnemyHoles;
    [SerializeField] private TutorialCursor m_sequencedEnemyCursor;



    private List<SequencedEnemy> m_sequencedEnemies;
    private NormalEnemy m_normalEnemy;
    private StrongEnemy m_strongEnemy;
    public void SpawnNormalEnemy()
    {
        m_normalEnemy = m_targetFactory.GetNormalEnemy();
        m_normalEnemyHole.SpawnTarget(m_normalEnemy);
    }

    public void HitNormalEnemy()
    {
        m_normalEnemyCursor.SetPressing(true);
        m_normalEnemy.OnHit();
    }

    public void SpawnStrongEnemy()
    {
        m_strongEnemy = m_targetFactory.GetStrongEnemy();
        m_strongEnemyHole.SpawnTarget(m_strongEnemy);
    }

    public void HitStrongEnemy()
    {
        m_strongEnemyCursor.SetPressing(true);
        m_strongEnemy.OnHit();
    }

    public void SpawnSequencedEnemy()
    {
        int sequenceLength = 3;
        m_sequencedEnemies = m_targetFactory.GetSequencedEnemies(sequenceLength);

        if (m_sequencedEnemies.Count != m_sequencedEnemyHoles.Count)
        {
            Debug.LogError("Sequenced enemy count and sequenced enemy holes count are not equal");
            return;
        }

        for (int i = 0; i < m_sequencedEnemies.Count; i++)
        {
            m_sequencedEnemyHoles[i].SpawnTarget(m_sequencedEnemies[i]);
        }
    }

    public void HitSeuqeuncedEnemy()
    {
        m_sequencedEnemyCursor.SetPressing(true);
        m_sequencedEnemies[0].OnHit();
        m_sequencedEnemies.RemoveAt(0);
    }
}
