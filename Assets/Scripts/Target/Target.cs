using UnityEngine;

public abstract class Target : MonoBehaviour
{
    private int m_score = 0;
    private float m_remainTime = 0.0f;

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
