using UnityEngine;

public class TutorialCursor : MonoBehaviour
{
    [SerializeField] private GameObject m_hammerCursor;
    [SerializeField] private GameObject m_hammerCursorPressed;

    public void SetPressing( bool isPressing )
    {
        m_hammerCursor.SetActive(!isPressing);
        m_hammerCursorPressed.SetActive(isPressing);
    }

    private void Start() 
    {
        SetPressing(false);
    }
}
