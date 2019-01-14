using UnityEngine;

public class ButtonManager : SingletonMonoBehaviour<ButtonManager>
{
    private GameObject startButton;

    public void Init()
    {
        startButton = GameObject.FindWithTag("StartButton");
    }

    public void Run()
    {
        
    }
    
    void Start()
    {
    }

    void Update()
    {
    }
    
    public void StartGameStartButton()
    {
        if (!startButton.activeSelf)
        {
            startButton.SetActive(true);
        }
    }

    public void StopGameStartButton()
    {
        if (startButton.activeSelf)
        {
            startButton.SetActive(false);
        }
    }
    
}