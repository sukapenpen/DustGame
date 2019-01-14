using UnityEngine;

public class TextManager : SingletonMonoBehaviour<TextManager>
{
	private GameObject gUIDustCounter;
	private GameObject theNumberOfDusts;
	private GameObject startCount;
	private GameObject gameTrashDustCounter;
	private GameObject resultText;

	private int realTrashDustCounter;
	private int gameStartCount;
	
	

	public void Init()
	{
		gameStartCount = 3;
		gUIDustCounter = GameObject.FindWithTag("DustCounter");
		theNumberOfDusts = GameObject.FindWithTag("TheNumberOfDusts");
		startCount = transform.Find("StartCount").gameObject;
		gameTrashDustCounter = transform.Find("GameTrashDustCounter").gameObject;
		resultText = transform.Find("ResultText").gameObject;
	}

	public void ResetManager()
	{
		realTrashDustCounter = 0;
		gUIDustCounter.GetComponent<TextMesh>().text = realTrashDustCounter.ToString();
		
	}

	public void TitleSet()
	{
		StartTextObject(gUIDustCounter);
		StartTextObject(theNumberOfDusts);
		StopTextObject(startCount);
		StopTextObject(gameTrashDustCounter);
		StopTextObject(resultText);
	}

	public void LoadSet()
	{
		StopTextObject(gUIDustCounter);
		StopTextObject(theNumberOfDusts);
		StartTextObject(startCount);
		StartTextObject(gameTrashDustCounter);
	}

	public void PlaySet()
	{
		StopTextObject(startCount);
		StartTextObject(gameTrashDustCounter);
	}

	public void ResultSet()
	{
		int _result = Incinerator.Instance.GameTrashDustCounter;
		StopTextObject(gameTrashDustCounter);
		resultText.GetComponent<TextMesh>().text = "結果\n" + _result + "個燃やせました！";
		StartTextObject(resultText);
	}

	public void UpdateDustCounter()
	{
		realTrashDustCounter = DustBox.Instance.RealTrashDustCounter;
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
