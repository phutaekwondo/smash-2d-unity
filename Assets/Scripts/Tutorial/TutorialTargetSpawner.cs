using UnityEngine;

public class TutorialTargetSpawner : MonoBehaviour
{
    [SerializeField] private TargetFactory m_targetFactory;
    [SerializeField] private Hole m_normalEnemyHole;
    public void SpawnNormalEnemy()
    {
        NormalEnemy normalEnemy = m_targetFactory.GetNormalEnemy();
        m_normalEnemyHole.SpawnTarget(normalEnemy);
    }
}
