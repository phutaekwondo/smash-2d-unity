using UnityEngine;
using TMPro;

public class GameOverSceneManager : MonoBehaviour
{
    [SerializeField] protected TMP_Text m_scoreText;
    [SerializeField] protected TMP_Text m_highScoreText;

    private void Start()
    {
        m_scoreText.text = GameManager.m_currentScore.ToString();
        m_highScoreText.text = GameManager.m_highScore.ToString();
    }
}
