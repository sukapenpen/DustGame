using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeDustBoxObj : MonoBehaviour
{

    private void OnTriggerEnter(Collider _object)
    {
        if (_object.gameObject.CompareTag("Dust"))
        {
            if (GameSceneManager.Instance.GetGameState() == GameState.Play)
            {
                Incinerator.Instance.GameTrashDustCounter += 1;
            }

        }
    }
    
}
