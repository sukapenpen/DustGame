using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    private void Awake()
    {
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
        switch (GameSceneManager.Instance.GetGameState())
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