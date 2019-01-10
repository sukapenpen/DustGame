using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Title,
    Load,
    Play
}

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private static GameState currentGamestate;

    private void Awake()
    {
        SerialManager.Instance.Init();
    }
    
    private void Start()
    {
    }

    public void Update()
    {
        switch (currentGamestate)
        {
            case GameState.Title:
                Instance.TitleAction();
                break;
            case GameState.Load:
                Instance.LoadAction();
                break;
            case GameState.Play:
                Instance.PlayAction();
                break;
        }
    }

    public void TitleAction()
    {
        SerialManager.Instance.Run();
    }

    public void LoadAction()
    {
        Debug.Log("ロードアクション");
    }

    public void PlayAction()
    {
        Debug.Log("プレイ中のアクション");
    }

    public void MakeDust()
    {
        //SerialManager.Instance.
    }
    
}