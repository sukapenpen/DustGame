using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SingletonMonoBehaviour<CameraManager>
{
	private GameObject titleCamera;
	private GameObject gameCamera;

	private void Awake()
	{
		titleCamera = transform.Find("TitleCamera").gameObject;
		gameCamera = transform.Find("GameCamera").gameObject;
	}

	private void Update()
	{
		if (GameSceneManager.Instance.GetGameState() == GameState.Title)
		{
			StartTitleCamera();
			StopGameCamera();
		}
		else
		{
			StartGameCamera();
			StopTitleCamera();
		}
	}

	private void StartTitleCamera()
	{
		if (!titleCamera.activeSelf)
		{
			titleCamera.SetActive(true);
		}
	}
	
	private void StopTitleCamera()
	{
		if (titleCamera.activeSelf)
		{
			titleCamera.SetActive(false);
		}
	}
	
	private void StartGameCamera()
	{
		if (!gameCamera.activeSelf)
		{
			gameCamera.SetActive(true);
		}
	}
	
	private void StopGameCamera()
	{
		if (gameCamera.activeSelf)
		{
			gameCamera.SetActive(false);
		}
	}
	
}
