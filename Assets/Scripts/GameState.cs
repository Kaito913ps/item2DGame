public class GameState
{
    static GameState _gameState;
    State _currentState;

    public static GameState Instance
    { 
        get 
        { 
            if(_gameState != null) return _gameState;
            
            _gameState = new GameState();
            _gameState.Init();
            return _gameState;
        } 
    }

    public State CurrentState => _currentState;

    public void Init()
    {
        _currentState = State.Ready;
    }

    public void ChangeState(State next)
    {
        _currentState = next;
    }
}

public enum State
{ 
    Ready,
    Play,
    Finish,
}


