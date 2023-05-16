using UnityEngine;
using TMPro;

public class GameOverSceneManager : MonoBehaviour
{
    [SerializeField] protected TMP_Text m_scoreText;

    private void Start()
    {
        m_scoreText.text = GameManager.m_currentScore.ToString();
    }
}
