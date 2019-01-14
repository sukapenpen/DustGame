using UnityEngine;

public sealed class DustManager : SingletonMonoBehaviour<DustManager>
{
	private GameObject[] dusts;
	private float[] xPositions;
	private float[] zPositions;
	private Vector2[] positions;

	[SerializeField]
	private GameObject dustPrefab;
	
	private int startDustCount;
	private int positionsCount;
	private int realTrashDustCounter;
	public int RealTrashDustCounter
	{
		get { return realTrashDustCounter; }
		private set { realTrashDustCounter = value; }
	}
	
	private int gamelTrashDustCounter;
	public int GamelTrashDustCounter
	{
		get { return gamelTrashDustCounter; }
		set { gamelTrashDustCounter = value; }
	}
	
	public void Init()
	{
		startDustCount = 10;
		positionsCount = 10;
		RealTrashDustCounter = 0;
		GamelTrashDustCounter = 0;
		dusts = new GameObject[startDustCount];
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
		for (int num = 0; num < startDustCount; num += 1)
		{
			dusts[num] = Instantiate(dustPrefab);
			dusts[num].SetActive(false);
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
		RealTrashDustCounter += 1;
	}
	
	public void AppearPlayingDust()
	{
		if (RealTrashDustCounter > 0)
		{
			GameObject dust = SeachFalseDust();
			dust.transform.position = new Vector3(xPositions[Random.Range(0, 10)], dust.transform.position.y,
				zPositions[Random.Range(0, 10)]);
			dust.SetActive(true);
		}
	}

}
