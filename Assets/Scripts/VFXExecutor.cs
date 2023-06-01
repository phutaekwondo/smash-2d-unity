using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VFXExecutor : MonoBehaviour
{
    public static VFXExecutor Instance { get; private set; }
    private void Awake() {
        Instance = this;
    }

    [SerializeField] private Image m_redWarningImage;
    [SerializeField] private float m_redWarningDefaultAlpha;

    [SerializeField] private GameObject m_hitEffectPrefab;

    private Color m_redWarningDefaultColor;

    private void Start() 
    {
        m_redWarningDefaultColor = m_redWarningImage.color;
        m_redWarningImage.color = new Color(
            m_redWarningDefaultColor.r, 
            m_redWarningDefaultColor.g, 
            m_redWarningDefaultColor.b, 
            0.0f); //make the red warning image transparent
    }

    public void HandleOnTargetHit(Target target)
    {
        PlayHitVFX(target.transform.position);
    }

    public void PlayHitVFX(Vector2 hitPosition)
    {
        GameObject hitEffect = Instantiate(m_hitEffectPrefab, hitPosition, Quaternion.identity);
    }

    public void PlayRedWarning()
    {
        StopAllCoroutines();
        StartCoroutine(PlayRedWarningAnimation());
    }

    private IEnumerator PlayRedWarningAnimation()
    {
        float disappearTime = 0.5f;
        m_redWarningImage.color = new Color(
                m_redWarningDefaultColor.r, 
                m_redWarningDefaultColor.g, 
                m_redWarningDefaultColor.b, 
                m_redWarningDefaultAlpha);

        while (m_redWarningImage.color.a > 0)
        {
            float currentAlpha = m_redWarningImage.color.a;
            float newAlpha = currentAlpha - m_redWarningDefaultAlpha*(Time.deltaTime / disappearTime);
            newAlpha = (newAlpha < 0) ? 0 : newAlpha;

            m_redWarningImage.color = new Color(
                m_redWarningDefaultColor.r, 
                m_redWarningDefaultColor.g, 
                m_redWarningDefaultColor.b, 
                newAlpha);
            yield return null;
        }
        yield return null;
    }
}
