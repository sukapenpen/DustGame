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
	
	//nullなのはfalseだから
	//ならタイトルにも使う？
	
	public void AddDustCounter()
	{
		dustCounter += 1;
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
