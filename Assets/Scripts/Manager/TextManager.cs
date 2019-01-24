using UnityEngine;

public class TextManager : SingletonMonoBehaviour<TextManager>
{
	private GameObject gUIDustCounter;
	private GameObject theNumberOfDusts;
	private GameObject gameName;
	private GameObject startCount;
	private GameObject gameTrashDustCounter;
	private GameObject theTrashedDustNumIs;
	private GameObject trashedDustNum;
	private GameObject resultText;


	//private int realTrashDustCounter;
	private int gameStartCount;
	
	

	public void Init()
	{
		gameStartCount = 3;
		gUIDustCounter = GameObject.FindWithTag("DustCounter");
		theNumberOfDusts = GameObject.FindWithTag("TheNumberOfDusts");
		gameName = GameObject.FindWithTag("GameName");
		startCount = transform.Find("StartCount").gameObject;
		gameTrashDustCounter = GameObject.FindWithTag("GameTrashDustCounter").gameObject;
		theTrashedDustNumIs = GameObject.FindWithTag("TheTrashedDustNumIs").gameObject;
		trashedDustNum = GameObject.FindWithTag("TrashedDustNum").gameObject;
		resultText = transform.Find("ResultText").gameObject;
	}

	public void ResetManager()
	{
		gUIDustCounter.GetComponent<TextMesh>().text = "0";
		
	}

	public void TitleSet()
	{
		StartTextObject(gUIDustCounter);
		StartTextObject(theNumberOfDusts);
		StartTextObject(gameName);
		StopTextObject(startCount);
		StopTextObject(gameTrashDustCounter);
		StopTextObject(theTrashedDustNumIs);
		StopTextObject(trashedDustNum);
		StopTextObject(resultText);
	}

	public void LoadSet()
	{
		StopTextObject(gUIDustCounter);
		StopTextObject(theNumberOfDusts);
		StopTextObject(gameName);
		StartTextObject(startCount);
		StartTextObject(gameTrashDustCounter);
		StartTextObject(theTrashedDustNumIs);
		StartTextObject(trashedDustNum);
		UpdateTrashedDustNum();
	}

	public void PlaySet()
	{
		StopTextObject(startCount);
		StartTextObject(gameTrashDustCounter);
		StartTextObject(theTrashedDustNumIs);
		StartTextObject(trashedDustNum);
	}

	public void ResultSet()
	{
		int _result = CountManager.Instance.GameTrashDustCounter;
		StopTextObject(gameTrashDustCounter);
		resultText.GetComponent<TextMesh>().text = "結果\n" + _result + "個燃やせました！";
		StartTextObject(resultText);
	}

	public void UpdateRealDustCounter()
	{
		gUIDustCounter.GetComponent<TextMesh>().text = CountManager.Instance.RealTrashDustCounter.ToString();
	}

	public void UpdateGameDustCounter()
	{
		gameTrashDustCounter.GetComponent<TextMesh>().text = CountManager.Instance.GameTrashDustCounter.ToString();
	}

	public void UpdateTrashedDustNum()
	{
		var dustDifference = CountManager.Instance.RealTrashDustCounter - CountManager.Instance.PlayingFallingCounter;
		trashedDustNum.GetComponent<TextMesh>().text = dustDifference.ToString();
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
