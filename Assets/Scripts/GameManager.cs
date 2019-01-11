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
        DustManager.Instance.Init();
        TextManager.Instance.Init();
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
        IntoDustBox();
    }

    private void LoadAction()
    {
        Debug.Log("ロードアクション");
    }

    private void PlayAction()
    {
        Debug.Log("プレイ中のアクション");
    }

    private void IntoDustBox()
    {
        var _dustDistance = SerialManager.Instance.ReadDistance();
        if (_dustDistance >= 0)
        {
            DustManager.Instance.AppearTitleDust();
            Debug.Log(_dustDistance + "cm");
        }
    }
    
}