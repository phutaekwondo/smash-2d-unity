using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake() {
        Instance = this;
    }

    public static int m_currentScore { get; private set; } = 0;
    public static int m_highScore { get; private set; } = 0;

    [SerializeField] protected GameMechanicExecutor m_gameMechanicExecutor;
    [SerializeField] protected TargetManager m_targetManager;
    [SerializeField] protected Player m_player;
    [SerializeField] protected TMP_Text m_scoreText;
    GameStateBase m_gameState;

    public void OnGameOver()
    {
        m_highScore = Math.Max(m_highScore, m_currentScore);
    }

    private void Start() 
    {
        m_gameState = new GameState_Playing(this);
    }

    private void Update() 
    {
        m_gameState.Update();
        m_targetManager.InternalUpdate();
        m_player.InternalUpdate();

        //update score text
        m_currentScore = m_player.GetScore();
        m_scoreText.text = "Score: " + m_player.GetScore().ToString();
    }

    class GameStateBase 
    {
        protected GameManager m_gameManager;
        public GameStateBase(GameManager gameManager) 
        {
            m_gameManager = gameManager;
        }
        virtual public void Update() {}
    }
    class GameState_Waiting : GameStateBase 
    {
        public GameState_Waiting(GameManager gameManager) : base(gameManager) 
        {
            throw new System.NotImplementedException();
        }
        override public void Update() 
        {
            throw new System.NotImplementedException();
        }
    }
    class GameState_Playing : GameStateBase 
    {
        GameMechanicExecutor m_gameMechanicExecutor;
        public GameState_Playing(GameManager gameManager) : base(gameManager) 
        {
            m_gameMechanicExecutor = gameManager.m_gameMechanicExecutor;
        }
        override public void Update() 
        {
            m_gameMechanicExecutor.UpdateInternal();
            if (m_gameMechanicExecutor.IsGameOver())
            {
                GameManager.Instance.OnGameOver(); 
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            }
        }
    }
    class GameState_Lost : GameStateBase 
    {
        public GameState_Lost(GameManager gameManager) : base(gameManager) 
        {
            throw new System.NotImplementedException();
        }
        override public void Update() 
        {
            throw new System.NotImplementedException();
        }
    }
    class GameState_Paused : GameStateBase 
    {
        public GameState_Paused(GameManager gameManager) : base(gameManager) 
        {
            throw new System.NotImplementedException();
        }
        override public void Update() 
        {
            throw new System.NotImplementedException();
        }
    }
}
