using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private uint m_score = 0;
    [SerializeField] private TMP_Text m_scoreText = null;

    private InputProvider m_inputProvider = null;

    public void InternalUpdate()
    {
        //temporarily use mouse position as input for testing
        Vector2? inputPosition = m_inputProvider.GetPressedPosition();
        if (inputPosition.HasValue)
        {
            DetectHitObject(inputPosition.Value);
            m_scoreText.text = inputPosition.Value.ToString();
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
    }
}
