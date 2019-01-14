using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeDustBoxObj : SingletonMonoBehaviour<JudgeDustBoxObj>
{

    private void OnTriggerEnter(Collider _object)
    {
        if (_object.gameObject.CompareTag("Dust"))
        {
            if (GameSceneManager.Instance.GetGameState() == GameState.Play)
            {
                DustManager.Instance.GamelTrashDustCounter += 1;
                Debug.Log("ゲーム中にゴミが入った！");
            }

            Debug.Log("ゴミが入った");
        }
    }
    
}
