using UnityEngine;

public enum GameState
{
    Title,
    Load,
    Play,
    Result
}

public class GameSceneManager
{
    private static GameState CurrentGamestate;
    private static GameSceneManager instance;

    public static GameSceneManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameSceneManager();
            }

            return instance;
        }
    }

    public GameState GetGameState()
    {
        return CurrentGamestate;
    }

    public void GoTitle()
    {
        CurrentGamestate = GameState.Title;
    }

    public void GoLoad()
    {
        CurrentGamestate = GameState.Load;
    }

    public void GoPlay()
    {
        CurrentGamestate = GameState.Play;
    }

    public void GoResult()
    {
        CurrentGamestate = GameState.Result;
    }
}