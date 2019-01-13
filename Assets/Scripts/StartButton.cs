using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	public void ClickStartButton()
	{
		GameSceneManager.Instance.GoLoad();
		Debug.Log("くりっくされた！");
	}
}
