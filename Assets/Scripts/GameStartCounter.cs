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
		gameStartCounter -= Time.deltaTime;
		if (gameStartCounter < gameStartfig)
		{
			gameStartfig -= 1;
			UpdateGameStartCount(gameStartfig);
		}
	}

	private void OnDisable()
	{
		gameStartfig = 3;
		gameStartCounter = 4.0f;
		GetComponent<TextMesh>().text = gameStartfig.ToString();
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
