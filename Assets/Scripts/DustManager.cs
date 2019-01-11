using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public sealed class DustManager : SingletonMonoBehaviour<DustManager>
{
	private static GameObject[] dusts;
	private static float[] xPositions;
	private static float[] zPositions;
	private static Vector2[] positions;

	[SerializeField]
	private GameObject dustPrefab;
	
	private int dustCount;
	private int positionsCount;
	
	public void Init()
	{
		dustCount = 20;
		positionsCount = 10;
		dusts = new GameObject[dustCount];
		this.CreateDust();
		//positions = new Vector2[positionsCount];
		xPositions = new float[positionsCount];
		zPositions = new float[positionsCount];
		CreatePosition();
	}

	public void Run()
	{
		
	}

	private void CreateDust()
	{
		for (int num = 0; num < dustCount; dustCount += 1)
		{
			dusts[num] = Instantiate(this.dustPrefab);
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
		Debug.Log(xPositions);
		Debug.Log(zPositions);
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
	
	public void AppearDust()
	{
		GameObject dust = SeachFalseDust();
		dust.transform.position = new Vector3(xPositions[Random.Range(0, 10)], dust.transform.position.y, zPositions[Random.Range(0, 10)]);
		dust.SetActive(true);
	}

}
