using UnityEngine;

public class InputKeyboardMouse : InputProvider
{
    public override Vector2? GetPressedPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return Input.mousePosition;
        }
        return null;
    }
}
