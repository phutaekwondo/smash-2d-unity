using System;
using UnityEngine;

public class TargetFactory : MonoBehaviour
{
    [SerializeField] private GameObject m_normalEnemyPrefab;

    internal NormalEnemy GetNormalEnemy()
    {
        throw new NotImplementedException();
    }
}
