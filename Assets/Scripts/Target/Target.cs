using System;
using UnityEngine;

public abstract class Target : MonoBehaviour
{
    protected int m_score = 0;
    protected float m_remainTime;
    protected float m_holdOnTime;
    protected Hole m_containedHole;

    public float GetHoldOnTime()
    {
        return m_holdOnTime;
    }
    public void JumpOut()
    {
        throw new System.NotImplementedException();
    }
    public void DrawIn()
    {
        throw new System.NotImplementedException();
    }
    public void Destroy() 
    {
        throw new System.NotImplementedException();
    }
    public void BeHitted()
    {
        throw new System.NotImplementedException();
    }
    public void SetHole(Hole hole)
    {
        m_containedHole = hole;
    }
    virtual public void SetOrderInLayer(int m_layerInOrderForTarget)
    {
        throw new NotImplementedException();
    }
}
