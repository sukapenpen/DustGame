using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private float playingTime;
    private int playingFallingCounter;
    private bool resetFlg;
    
    private void Awake()
    {        
        resetFlg = false;
        SerialManager.Instance.Init();
        DustManager.Instance.Init();
        TextManager.Instance.Init();
        DustBox.Instance.Init();
        ButtonManager.Instance.Init();
    }

    private void Update()
    {
        switch (GameSceneManager.Instance.GetGameState())
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
            case GameState.Result:
                ResultAction();
                break;
        }
    }

    private void TitleAction()
    {
        ResetAllManager();
        TextManager.Instance.TitleSet();
        ButtonManager.Instance.TitleSet();
        IsRealDustIntoDustBox();
    }

    private void LoadAction()
    {
        resetFlg = false;
        TextManager.Instance.LoadSet();
        ButtonManager.Instance.LoadSet();
    }

    private void PlayAction()
    {
        playingTime += Time.deltaTime;
        PlayingFallDust();
        DustBox.Instance.Move();
        TextManager.Instance.PlaySet();
    }

    private void ResultAction()
    {
        TextManager.Instance.ResultSet();
        ButtonManager.Instance.ResultSet();
    }

    private void ResetAllManager()
    {
        if (!resetFlg)
        {
            DustManager.Instance.ResetManager();
            DustBox.Instance.ResetManager();
            TextManager.Instance.ResetManager();
            playingTime = 0;
            playingFallingCounter = 0;
            resetFlg = true;
        }
    }

    private void IsRealDustIntoDustBox()
    {
        var _dustDistance = SerialManager.Instance.ReadDistance();
        
        if (_dustDistance >= 0)
        {
            DustManager.Instance.AppearTitleDust();
            DustBox.Instance.AddRealDust();
            TextManager.Instance.UpdateDustCounter();
        }
    }

    private void PlayingFallDust()
    {
        var _sec = 4;
        
        if (playingFallingCounter < DustBox.Instance.RealTrashDustCounter)
        {
            if (playingTime / _sec >= playingFallingCounter)
            {
                DustManager.Instance.AppearPlayingDust();
                playingFallingCounter += 1;
            }
        }

        if (playingFallingCounter == DustBox.Instance.RealTrashDustCounter)
        {
            if (playingTime / _sec >= playingFallingCounter)
            {
                GameSceneManager.Instance.GoResult();
            }
        }
    }
    
}