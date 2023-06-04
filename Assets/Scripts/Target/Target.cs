using System.Collections;
using UnityEngine;

public delegate void OnTargetSmashHandler(Target target);
public delegate void OnTargetHitHanlder(Target target);

public abstract class Target : MonoBehaviour
{
    public enum Type
    {
        NormalEnemy,
        StrongEnemy,
        Ally,
        SequencedEnemy,
    }

    protected TargetSpecification m_specification;

    protected int m_remainHitTimes = 1;
    protected float m_remainTime;
    protected Hole m_containedHole;
    public event OnTargetSmashHandler m_onTargetSmashEvent;
    public event OnTargetHitHanlder m_onTargetHitEvent;

    public Target()
    {
        if (VFXExecutor.Instance != null)
        {
            m_onTargetHitEvent += VFXExecutor.Instance.HandleOnTargetHit;
        }
    }

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
        if (TargetManager.Instance != null)
        {
            TargetManager.Instance.RemoveTarget(this);
        }
        Destroy(this.gameObject);
    }
    virtual public void OnHit()
    {
        if (m_remainHitTimes <= 0) return;
        m_onTargetHitEvent?.Invoke(this);

        m_remainHitTimes--;
    }

    public void SetHole(Hole hole)
    {
        m_containedHole = hole;
    }

    protected void OnSmash()
    {
        m_onTargetSmashEvent?.Invoke(this);
    }

    // PRIVATE METHODS
    private IEnumerator JumpOutAnimation()
    {
        float deep = 1.5f;

        //[temporary fix] check specification null to avoid bug in Tutorial scene
        float ratioSpeed;
        if (m_specification != null)
        {
            ratioSpeed = GetSpecification().m_linearRatioSpeed;
        }
        else
        {
            ratioSpeed = 3f;
        }

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
        //[temporary fix] check specification null to avoid bug in Tutorial scene
        float ratioSpeed;
        if (m_specification != null)
        {
            ratioSpeed = GetSpecification().m_linearRatioSpeed;
        }
        else
        {
            ratioSpeed = 3f;
        }

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
