using UnityEngine;

public class InputKeyboardMouse : InputProvider
{
    private KeyCode m_firstKey = KeyCode.Z;
    private KeyCode m_secondKey = KeyCode.X;
    public override Vector2? GetPressedPosition()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(m_firstKey) || Input.GetKeyDown(m_secondKey))
        {
            return Input.mousePosition;
        }
        return null;
    }
}
