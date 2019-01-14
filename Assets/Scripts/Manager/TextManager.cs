using UnityEngine;

public class TextManager : SingletonMonoBehaviour<TextManager>
{
	private GameObject gUIDustCounter;
	private GameObject theNumberOfDusts;
	private GameObject startCount;
	private int realTrashDustCounter;
	private int gameStartCount;

	public void Init()
	{
		realTrashDustCounter = 0;
		gameStartCount = 3;
		gUIDustCounter = GameObject.FindWithTag("DustCounter");
		theNumberOfDusts = GameObject.FindWithTag("TheNumberOfDusts");
		gUIDustCounter.GetComponent<TextMesh>().text = realTrashDustCounter.ToString();
		startCount = transform.Find("StartCount").gameObject;
	}
	
	public void UpdateDustCounter()
	{
		realTrashDustCounter = DustManager.Instance.RealTrashDustCounter;
		gUIDustCounter.GetComponent<TextMesh>().text = realTrashDustCounter.ToString();
	}
	
	public void StartGameStartCount()
	{
		if (!startCount.activeSelf)
		{
			startCount.SetActive(true);
		}
	}
	
}
