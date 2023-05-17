using UnityEngine;

public class MenuEventHandler : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Prototype");
    }
    public void OnPlayAgainButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Prototype");
    }
}
