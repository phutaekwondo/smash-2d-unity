using System;
using System.Collections;
using UnityEngine;

public delegate void OnTargetHitHandler(Target.Type type);

public abstract class Target : MonoBehaviour
{
    public enum Type
    {
        NormalEnemy,
        Ally,
    }

    protected int m_remainHitTimes = 1;
    protected Type m_type;
    public event OnTargetHitHandler m_onTargetHitEvent;
    public static int m_score { get; protected set; } = 0 ;
    protected float m_remainTime;
    protected float m_holdOnTime;
    protected Hole m_containedHole;

    public void InternalUpdate()
    {
        if (m_remainTime <= 0) return;

        m_remainTime -= Time.deltaTime;

        if (m_remainTime<=0)
        {
            DrawIn();
        }
    }

    public float GetHoldOnTime()
    {
        return m_holdOnTime;
    }
    public void JumpOut()
    {
        StopAllCoroutines();
        StartCoroutine(JumpOutAnimation());
    }
    public void DrawIn()
    {
        StopAllCoroutines();
        StartCoroutine(DrawInAnimation());
    }
    public void RemoveFromPlay() 
    {
        m_containedHole.SetEmpty(true);
        TargetManager.Instance.RemoveTarget(this);
        Destroy(this.gameObject);
    }
    virtual public void OnHit()
    {
        if (m_remainHitTimes <= 0) return;

        m_remainHitTimes--;
        m_onTargetHitEvent?.Invoke(m_type);
    }
    public void SetHole(Hole hole)
    {
        m_containedHole = hole;
    }
    virtual public void SetOrderInLayer(int m_layerInOrderForTarget)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = m_layerInOrderForTarget;
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

        while (transform.position.y > endPosition.y)
        {
            transform.position = transform.position + ((Vector3)moveDirection * Time.deltaTime);

            yield return null;
        }

        transform.position = endPosition;

        RemoveFromPlay();
        yield return null;
    }
}
