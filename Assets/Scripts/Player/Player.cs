using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Texture2D m_hammerCursor;
    [SerializeField] private Texture2D m_hammerCursorPressed;
    private Vector2 m_cursorHotspot;
    private int m_score = 0;
    private const int MIN_SCORE = 0;

    private InputProvider m_inputProvider = null;

    public void InternalUpdate()
    {
        //temporarily use mouse position as input for testing
        Vector2? inputPosition = m_inputProvider.GetPressedPosition();
        if (inputPosition.HasValue)
        {
            DetectHitObject(inputPosition.Value);
        }

        //set cursor based on input
        bool IsPressing = m_inputProvider.IsPressing();
        if (IsPressing)
        {
            Cursor.SetCursor(m_hammerCursorPressed, m_cursorHotspot, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(m_hammerCursor, m_cursorHotspot, CursorMode.Auto);
        }
    }

    public int GetScore()
    {
        return m_score;
    }

    public void IncreaseScore(int score)
    {
        m_score += score;
        if (m_score < MIN_SCORE)
        {
            m_score = MIN_SCORE;
        }
    }

    public void DetectHitObject(Vector2 hitPosition)
    {
        Vector2 touchPosWorld2D = (Vector2)Camera.main.ScreenToWorldPoint(hitPosition);
        RaycastHit2D hitInfo = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
        if (hitInfo.collider != null)
        {
            OnHit(hitInfo.collider.gameObject);
        }
    }

    public void OnHit(GameObject hittedObject) 
    {
        if (hittedObject.CompareTag("Target"))
        {
            hittedObject.GetComponent<Target>().OnHit();
        }
    }

    private void Start() 
    {
        m_inputProvider = new InputKeyboardMouse();
        m_cursorHotspot = new Vector2(m_hammerCursor.width / 4, m_hammerCursor.height / 2);
        Cursor.SetCursor(m_hammerCursor, m_cursorHotspot, CursorMode.Auto);
    }
}
