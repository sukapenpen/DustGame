using UnityEngine;

public class TextManager : SingletonMonoBehaviour<TextManager>
{
	private GameObject gUIDustCounter;
	private GameObject theNumberOfDusts;
	private GameObject startCount;
	private int dustCounter;
	private int gameStartCount;

	public void Init()
	{
		dustCounter = 0;
		gameStartCount = 3;
		gUIDustCounter = GameObject.FindWithTag("DustCounter");
		theNumberOfDusts = GameObject.FindWithTag("TheNumberOfDusts");
		gUIDustCounter.GetComponent<TextMesh>().text = dustCounter.ToString();
		startCount = transform.Find("StartCount").gameObject;
	}
	
	public void UpdateDustCounter()
	{
		dustCounter = DustManager.Instance.DustCounter;
		gUIDustCounter.GetComponent<TextMesh>().text = dustCounter.ToString();
	}
	
	public void StartGameStartCount()
	{
		if (!startCount.activeSelf)
		{
			startCount.SetActive(true);
		}
	}
	
}
