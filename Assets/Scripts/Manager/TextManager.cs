using UnityEngine;

public class TextManager : SingletonMonoBehaviour<TextManager>
{
	private GameObject gUIDustCounter;
	private GameObject theNumberOfDusts;
	private GameObject startCount;
	private GameObject gameTrashDustCounter;

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
		gameTrashDustCounter = transform.Find("GameTrashDustCounter").gameObject;
	}

	public void TitleRun()
	{
		StartTextObject(gUIDustCounter);
		StartTextObject(theNumberOfDusts);
		StopTextObject(startCount);
		StopTextObject(gameTrashDustCounter);
	}

	public void LoadRun()
	{
		StopTextObject(gUIDustCounter);
		StopTextObject(theNumberOfDusts);
		StartTextObject(startCount);
		StartTextObject(gameTrashDustCounter);
	}

	public void PlayRun()
	{
		StopTextObject(gUIDustCounter);
		StopTextObject(theNumberOfDusts);
		StopTextObject(startCount);
		StartTextObject(gameTrashDustCounter);
	}

	public void UpdateDustCounter()
	{
		realTrashDustCounter = DustManager.Instance.RealTrashDustCounter;
		gUIDustCounter.GetComponent<TextMesh>().text = realTrashDustCounter.ToString();
	}

	private void StartTextObject(GameObject _obj)
	{
		if (!_obj.activeSelf)
		{
			_obj.SetActive(true);
		}
	}
	
	private void StopTextObject(GameObject _obj)
	{
		if (_obj.activeSelf)
		{
			_obj.SetActive(false);
		}
	}
	
}
