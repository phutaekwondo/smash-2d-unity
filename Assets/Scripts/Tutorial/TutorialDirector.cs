using UnityEngine;

public class TutorialDirector : MonoBehaviour
{
    [SerializeField] private TargetFactory m_targetFactory;
    [SerializeField] private Hole m_normalEnemyHole;
    [SerializeField] private TutorialCursor m_normalEnemyCursor;
    private NormalEnemy m_normalEnemy;
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
        Debug.Log("SpawnStrongEnemy");
    }
}
