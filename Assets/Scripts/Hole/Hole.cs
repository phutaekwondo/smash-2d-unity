using UnityEngine;

public class Hole : MonoBehaviour
{
    private bool m_isEmpty = true;
    private Vector2 m_position;
    [SerializeField] private int m_layerInOrderForTarget = 1;

    private void Start() 
    {
        m_position = transform.position;
    }
    public void SpawnTarget(Target target)
    {
        target.gameObject.transform.position = m_position;
        target.SetOrderInLayer(m_layerInOrderForTarget);
        target.SetHole(this);
        target.JumpOut();
        m_isEmpty = false;
    }
    public bool IsEmpty()
    {
        return m_isEmpty;
    }
}
