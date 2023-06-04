using UnityEngine;

public class MenuEventHandler : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Prototype");
    }
    public void OnTutorialButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial");
    }
    public void OnMenuButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }
    public void OnPlayAgainButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Prototype");
    }
}
