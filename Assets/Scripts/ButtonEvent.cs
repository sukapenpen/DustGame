using UnityEngine;

public class ButtonEvent : MonoBehaviour {

	public void ClickStartButton()
	{
		if (CountManager.Instance.RealTrashDustCounter > 0)
		{
			GameSceneManager.Instance.GoLoad();
		}
		Debug.Log("くりっくされた！");
	}
	
	public void ClickReturnTitleButton()
	{
		GameSceneManager.Instance.GoTitle();
		Debug.Log("タイトルボタンがくりっくされた！");
	}

	public void ClickResetButton()
	{
		CountManager.Instance.RealTrashReset();
		TextManager.Instance.UpdateRealDustCounter();
		Debug.Log("リセットボタンがくりっくされた！");
	}
	
}
 