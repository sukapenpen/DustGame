using UnityEngine;

public class ButtonEvent : MonoBehaviour {

	public void ClickStartButton()
	{
		GameSceneManager.Instance.GoLoad();
		Debug.Log("くりっくされた！");
	}
	
	public void ClickReturnTitleButton()
	{
		GameSceneManager.Instance.GoTitle();
		Debug.Log("タイトルボタンがくりっくされた！");
	}

	public void ClickResetButton()
	{
		DustBox.Instance.ResetDust();
		TextManager.Instance.UpdateDustCounter();
		Debug.Log("リセットボタンがくりっくされた！");
	}
	
}
