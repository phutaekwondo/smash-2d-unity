using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEventHandler : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Prototype");
    }
}
