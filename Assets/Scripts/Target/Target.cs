using System.Collections;
using UnityEngine;

public delegate void OnTargetHitHandler(Target target);

public abstract class Target : MonoBehaviour
{
    public enum Type
    {
        NormalEnemy,
        StrongEnemy,
        Ally,
    }

    protected TargetSpecification m_specification;

    protected int m_remainHitTimes = 1;
    protected float m_remainTime;
    protected Hole m_containedHole;
    public event OnTargetHitHandler m_onTargetSmashEvent;

    virtual public void InternalUpdate()
    {
        if (m_remainTime <= 0) return;

        m_remainTime -= Time.deltaTime;

        if (m_remainTime<=0)
        {
            DrawIn();
        }
    }
    public void SetSpecification(TargetSpecification specification)
    {
        this.m_specification = specification;
    }
    public TargetSpecification GetSpecification()
    {
        return this.m_specification;
    }

    public float GetHoldOnTime()
    {
        return GetSpecification().m_holdOnTime;
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
        if (m_remainHitTimes <= 0)
        {
            m_onTargetSmashEvent?.Invoke(this);
        }
    }
    public void SetHole(Hole hole)
    {
        m_containedHole = hole;
    }

    // PRIVATE METHODS
    private IEnumerator JumpOutAnimation()
    {
        float deep = 1.5f;
        float ratioSpeed = GetSpecification().m_linearRatioSpeed;

        Vector3 endPosition = transform.position;
        Vector3 startPosition = endPosition - new Vector3(0.0f, deep);
        Vector3 moveDirection = (endPosition - startPosition) * ratioSpeed;

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
        float ratioSpeed = GetSpecification().m_linearRatioSpeed;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition - new Vector3(0.0f, deep);
        Vector3 moveDirection = (endPosition - startPosition) * ratioSpeed;

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
