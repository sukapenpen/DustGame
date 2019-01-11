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
    private float dustDistance;

    private void Awake()
    {
        SerialManager.Instance.Init();
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
        DustAppearTrigger();
    }

    private void LoadAction()
    {
        Debug.Log("ロードアクション");
    }

    private void PlayAction()
    {
        Debug.Log("プレイ中のアクション");
    }

    private void SerialInput()
    {
        dustDistance = SerialManager.Instance.ReadDistance();
        Debug.Log(dustDistance);
    }

    private void DustAppearTrigger()
    {
        dustDistance = SerialManager.Instance.ReadDistance();
        if (dustDistance >= 0)
        {
            DustManager.Instance.AppearDust();
            Debug.Log(dustDistance);
        }
        else
        {
            Debug.Log("エラー出てるぞー！");
        }
    }

    private void MakeDust()
    {
        //SerialManager.Instance.
    }
    
}