using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private float playingTime;
    private int playingFallingCounter;
    private bool resetFlg;
    
    private void Awake()
    {        
        resetFlg = false;
        CountManager.Instance.Init();
        SerialManager.Instance.Init();
        DustManager.Instance.Init();
        TextManager.Instance.Init();
        ButtonManager.Instance.Init();
        PlayerManager.Instance.Init();
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
        PlayerManager.Instance.TitleSet();
        IsRealDustIntoDustBox();
        DebugTitle();
    }

    private void LoadAction()
    {
        resetFlg = false;
        TextManager.Instance.LoadSet();
        ButtonManager.Instance.LoadSet();
        PlayerManager.Instance.LoadSet();
        DustManager.Instance.LoadSet();
    }

    private void PlayAction()
    {
        playingTime += Time.deltaTime;
        PlayingFallDust();
        TextManager.Instance.PlaySet();
        TextManager.Instance.UpdateGameDustCounter();
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
            TextManager.Instance.ResetManager();
            CountManager.Instance.ResetManager();
            DustManager.Instance.ResetManager();
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
            CountManager.Instance.RealTrashAdd();
            TextManager.Instance.UpdateRealDustCounter();
        }
    }

    private void DebugTitle()
    {
        if (Input.GetKey(KeyCode.A))
        {
            DustManager.Instance.AppearTitleDust();
            CountManager.Instance.RealTrashAdd();
            TextManager.Instance.UpdateRealDustCounter();
        }
    }

    private void PlayingFallDust()
    {
        var _sec = 4;
        
        if (playingFallingCounter < CountManager.Instance.RealTrashDustCounter)
        {
            if (playingTime / _sec >= playingFallingCounter)
            {
                DustManager.Instance.AppearPlayingDust();
                playingFallingCounter += 1;
            }
        }

        if (playingFallingCounter == CountManager.Instance.RealTrashDustCounter)
        {
            if (playingTime / _sec >= playingFallingCounter)
            {
                GameSceneManager.Instance.GoResult();
            }
        }
    }
    
}