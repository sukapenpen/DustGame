﻿using UnityEngine;

public sealed class DustManager : SingletonMonoBehaviour<DustManager>
{
	private GameObject[] dusts;
	private float[] xPositions;
	private float[] zPositions;
	private Vector2[] positions;

	[SerializeField]
	private GameObject dustPrefab;
	
	private int dustCount;
	private int positionsCount;
	
	public void Init()
	{
		dustCount = 5;
		positionsCount = 10;
		dusts = new GameObject[dustCount];
		CreateDust();
		xPositions = new float[positionsCount];
		zPositions = new float[positionsCount];
		CreatePosition();	
	}

	public void Run()
	{
		
	}

	private void CreateDust()
	{
		for (int num = 0; num < dustCount; num += 1)
		{
			dusts[num] = Instantiate(dustPrefab);
			dusts[num].SetActive(false);
			dusts[num].GetComponent<Rigidbody>().sleepThreshold = -1;
		}
	}

	private void CreatePosition()
	{
		float position = -9.0f;
		float equalPosition = 18.0f / positionsCount;
		
		for (int num = 0; num < positionsCount; num += 1)
		{
			xPositions[num] = position;
			zPositions[num] = position;
			position += equalPosition;
		}
	}

	public GameObject SeachFalseDust()
	{
		for (int num = 0; num < dusts.Length; num += 1)
		{
			if (!dusts[num].activeSelf)
			{
				return dusts[num];
			}
		}

		return null;
	}

	public void AppearTitleDust()
	{
		GameObject dust = SeachFalseDust();
		dust.SetActive(true);
	}
	
	public void AppearPlayingDust()
	{
		GameObject dust = SeachFalseDust();
		dust.transform.position = new Vector3(xPositions[Random.Range(0, 10)], dust.transform.position.y, zPositions[Random.Range(0, 10)]);
		dust.SetActive(true);
	}

}