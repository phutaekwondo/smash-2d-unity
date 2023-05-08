using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected GameMechanicExecutor m_gameMechanicExecutor;
    [SerializeField] protected TargetManager m_targetManager;
    GameStateBase m_gameState;

    private void Start() 
    {
        m_gameState = new GameState_Playing(this);
    }

    private void Update() 
    {
        m_gameState.Update();
        m_targetManager.InternalUpdate();
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
