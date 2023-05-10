using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private uint m_score = 0;
    [SerializeField] private TMP_Text m_scoreText = null;

    private InputProvider m_inputProvider = null;

    private void Start() 
    {
        m_inputProvider = new InputKeyboardMouse();
    }

    private void Update() 
    {
        //temporarily use mouse position as input for testing
        Vector2? inputPosition = m_inputProvider.GetPressedPosition();

        // show the input position on the screen for testing
        if (inputPosition.HasValue)
        {
            m_scoreText.text = inputPosition.Value.ToString();
        }
    }
}
