using UnityEngine;

public class ButtonManager : SingletonMonoBehaviour<ButtonManager>
{
    private GameObject startButton;
    private GameObject returnTitleButton;
    private GameObject resetDustButton;


    public void Init()
    {
        startButton = GameObject.FindWithTag("StartButton");
        resetDustButton = GameObject.FindWithTag("ResetDustButton");
        returnTitleButton = transform.Find("ReturnTitleButton").gameObject;
    }

    public void TitleSet()
    {
        StartButtonObject(startButton);
        StartButtonObject(resetDustButton);
        StopButtonObject(returnTitleButton);
    }

    public void LoadSet()
    {
        StopButtonObject(startButton);
        StopButtonObject(resetDustButton);
    }

    public void PlaySet()
    {
        
    }

    public void ResultSet()
    {
        StartButtonObject(returnTitleButton);
    }
    
    private void StartButtonObject(GameObject _obj)
    {
        if (!_obj.activeSelf)
        {
            _obj.SetActive(true);
        }
    }
    
    private void StopButtonObject(GameObject _obj)
    {
        if (_obj.activeSelf)
        {
            _obj.SetActive(false);
        }
    }
    
}