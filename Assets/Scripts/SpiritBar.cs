using UnityEngine;
using UnityEngine.UI;

public class SpiritBar : MonoBehaviour
{
    private const int MAX_SPIRIT = 100;
    private const int MIN_SPIRIT = 0;
    private float m_spirit = 100;
    private float m_spiritDropSpeed= 20; //per second

    [SerializeField] private Image m_spiritBarMask;

    public void IncreaseSpririt(float amount)
    {
        m_spirit += amount;
        if (m_spirit > MAX_SPIRIT)
        {
            m_spirit = MAX_SPIRIT;
        }
        else if (m_spirit < MIN_SPIRIT)
        {
            m_spirit = MIN_SPIRIT;
        }
    }

    public void InternalUpdate()
    {

        if (m_spirit > 0)
        {
            m_spirit -= m_spiritDropSpeed * Time.deltaTime;
            if (m_spirit < MIN_SPIRIT)
            {
                m_spirit = MIN_SPIRIT;
            }
        }

        m_spiritBarMask.fillAmount = m_spirit / MAX_SPIRIT;
    }
}
