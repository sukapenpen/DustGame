using UnityEngine;

public class GameStartCounter : MonoBehaviour
{
	private int gameStartfig;
	private float gameStartCounter;
	
	private void Awake ()
	{
		this.gameObject.SetActive(false);
	}

	private void Update ()
	{
		CountTime();
	}

	private void OnDisable()
	{
		gameStartfig = 3;
		gameStartCounter = 4.0f;
		GetComponent<TextMesh>().text = gameStartfig.ToString();
	}

	private void CountTime()
	{
		gameStartCounter -= Time.deltaTime;
		if (gameStartCounter < gameStartfig)
		{
			gameStartfig -= 1;
			UpdateGameStartCount(gameStartfig);
		}
	}

	public void UpdateGameStartCount(int _count)
	{
		if (_count == 0)
		{
			GetComponent<TextMesh>().text = "スタート！";
		}
		else if (_count > 0)
		{
			GetComponent<TextMesh>().text = _count.ToString();
		}
		else
		{
			GameSceneManager.Instance.GoPlay();
			this.gameObject.SetActive(false);
		}
	}
	
}
