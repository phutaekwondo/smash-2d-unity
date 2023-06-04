using UnityEngine;

public class TutorialDirector : MonoBehaviour
{
    [SerializeField] private TargetFactory m_targetFactory;

    [SerializeField] private Hole m_normalEnemyHole;
    [SerializeField] private TutorialCursor m_normalEnemyCursor;

    [SerializeField] private Hole m_strongEnemyHole;
    [SerializeField] private TutorialCursor m_strongEnemyCursor;


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
}
