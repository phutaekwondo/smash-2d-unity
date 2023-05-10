using UnityEngine;

abstract public class InputProvider : MonoBehaviour
{
    abstract public Vector2? GetPressedPosition();
}
