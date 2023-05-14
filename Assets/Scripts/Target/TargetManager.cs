using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    //Singleton
    public static TargetManager Instance { get; private set; }
    private void Awake() 
    {
        Instance = this;
    }

    List<Target> m_targets = new List<Target>();

    public void AddTarget(Target target)
    {
        m_targets.Add(target);
    }
    public void RemoveTarget(Target target)
    {
        m_targets.Remove(target);
    }

    public void InternalUpdate()
    {
        foreach (Target target in m_targets)
        {
            target.InternalUpdate();
        }
    }
}
