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
        currentGamestate = GameState.Title;
        SerialManager.Instance.Init();
        DustManager.Instance.Init();
        TextManager.Instance.Init();
        DustBox.Instance.Init();
    }
    
    private void Start()
    {
    }

    private void Update()
    {
        switch (currentGamestate)
        {
            case GameState.Title:
                TitleAction();
                //SerialManager.Instance.TestRead();
                //SerialManager.Instance.Run();
                break;
            case GameState.Load:
                LoadAction();
                break;
            case GameState.Play:
                PlayAction();
                break;
        }
    }

    private void TitleAction()
    {
        var _dustDistance = SerialManager.Instance.ReadDistance();
        
        if (_dustDistance >= 0)
        {
            RealDustIntoDustBox();
        }
    }

    private void LoadAction()
    {
        Debug.Log("ロードアクション");
    }

    private void PlayAction()
    {
        Debug.Log("プレイ中のアクション");
        DustBox.Instance.Move();
    }

    private void RealDustIntoDustBox()
    {
        DustManager.Instance.AppearTitleDust();
        TextManager.Instance.AddDustCounter();
    }
    
}