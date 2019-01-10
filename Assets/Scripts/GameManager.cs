using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Title,
    Load,
    Play
}

public class GameManager : MonoBehaviour
{
    private static GameState currentGamestate;

    private void Awake()
    {
        
    }
    
    private void Start()
    {
        SerialManager.Instance.Init();
    }

    private void Update()
    {
        SerialManager.Instance.Run();
        switch (hideFlags)
        {
                
        }
    }

    private void MakeDust()
    {
        //SerialManager.Instance.
    }
    
}