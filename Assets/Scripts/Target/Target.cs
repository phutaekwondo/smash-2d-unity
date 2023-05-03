using UnityEngine;

public abstract class Target : MonoBehaviour
{
    protected int m_score = 0;
    protected float m_remainTime = 0.0f;
    protected float m_holdOnTime = 0.0f;

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
}
