using UnityEngine;

public class StartButton : MonoBehaviour {

	public void ClickStartButton()
	{
		GameSceneManager.Instance.GoLoad();
		Debug.Log("くりっくされた！");
	}
}
