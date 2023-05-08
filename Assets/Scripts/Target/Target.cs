using System;
using System.Collections;
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
        //play jump out animation
        StartCoroutine(JumpOutAnimation());
    }
    public void DrawIn()
    {
        StartCoroutine(DrawInAnimation());
    }
    public void Smashed() 
    {
        m_containedHole.SetEmpty(true);
        Destroy(this.gameObject);
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

    // PRIVATE METHODS
    private IEnumerator JumpOutAnimation()
    {
        float deep = 1.5f;
        float ratioSpeed = 1.5f;

        Vector2 endPosition = transform.position;
        Vector2 startPosition = endPosition - new Vector2(0.0f, deep);
        Vector2 moveDirection = (endPosition - startPosition) * ratioSpeed;

        this.transform.position = startPosition;

        while (transform.position.y < endPosition.y)
        {
            transform.position = transform.position + ((Vector3)moveDirection * Time.deltaTime);

            yield return null;
        }

        transform.position = endPosition;

        yield return null;
    }
    private IEnumerator DrawInAnimation()
    {
        float deep = 1.5f;
        float ratioSpeed = 1.5f;

        Vector2 startPosition = transform.position;
        Vector2 endPosition = startPosition - new Vector2(0.0f, deep);
        Vector2 moveDirection = (endPosition - startPosition) * ratioSpeed;

        this.transform.position = startPosition;

        while (transform.position.y < endPosition.y)
        {
            transform.position = transform.position + ((Vector3)moveDirection * Time.deltaTime);

            yield return null;
        }

        transform.position = endPosition;

        Smashed();
        yield return null;
    }
}
