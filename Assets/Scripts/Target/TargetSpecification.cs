public class TargetSpecification 
{
    public Target.Type m_type { get; private set; }
    public int m_score { get; private set; } = 0 ;
    public int m_hitDuration { get; private set; } = 1;
    public float m_spiritAmount { get; private set; } = 0 ;
    public float m_holdOnTime { get; private set; } = 0 ;
    public float m_linearRatioSpeed { get; private set; } = 3f ;

    public TargetSpecification(Target.Type type,int hitDuration, int score, float holdOnTime, float spiritAmount)
    {
        m_type = type;
        m_hitDuration = hitDuration;
        m_score = score;
        m_holdOnTime = holdOnTime;
        m_spiritAmount = spiritAmount;
    }
}
