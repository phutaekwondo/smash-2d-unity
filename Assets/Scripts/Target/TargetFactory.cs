using System;
using UnityEngine;

public class TargetFactory : MonoBehaviour
{
    [SerializeField] private GameObject m_normalEnemyPrefab;

    internal NormalEnemy GetNormalEnemy()
    {
        //create a normal enemy
        GameObject normalEnemyGameObject = Instantiate(m_normalEnemyPrefab);
        NormalEnemy normalEnemy = normalEnemyGameObject.GetComponent<NormalEnemy>();
        return normalEnemy;
    }
}
