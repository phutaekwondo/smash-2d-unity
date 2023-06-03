using UnityEngine;

abstract public class InputProvider 
{
    abstract public Vector2? GetPressedPosition();
    abstract public bool IsPressing();
}
