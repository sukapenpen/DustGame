using UnityEngine;

public sealed class DustManager : SingletonMonoBehaviour<DustManager>
{
	private GameObject[] dusts;
	private float[] xPositions;
	private float[] zPositions;
	private Vector2[] positions;

	[SerializeField]
	private GameObject dustPrefab;
	
	private int createDustCount;
	private int positionsCount;
	
	
	public void Init()
	{
		createDustCount = 100;
		positionsCount = 10;
		dusts = new GameObject[createDustCount];
		CreateDust();
		xPositions = new float[positionsCount];
		zPositions = new float[positionsCount];
		CreatePosition();
	}

	public void LoadSet()
	{
		HideAllDusts();
	}

	public void ResetManager()
	{
		HideAllDusts();
	}

	private void CreateDust()
	{
		for (int num = 0; num < createDustCount; num += 1)
		{
			dusts[num] = Instantiate(dustPrefab);
			dusts[num].SetActive(false);
		}
	}

	private void CreatePosition()
	{
		float xPos = -7.0f;
		float zPos = -5.0f;
		float xEqualPos = (xPos * 2) / positionsCount;
		float zEqualPos = (zPos * 2) / positionsCount;
		
		for (int num = 0; num < positionsCount; num += 1)
		{
			Debug.Log(zPos);
			xPositions[num] = xPos;
			zPositions[num] = zPos;
			xPos -= xEqualPos;
			zPos -= zEqualPos;
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
		if (CountManager.Instance.RealTrashDustCounter > 0)
		{
			GameObject dust = SeachFalseDust();
			dust.transform.position = new Vector3(xPositions[Random.Range(0, 10)], dust.transform.position.y + 9,
				zPositions[Random.Range(0, 10)]);
			dust.SetActive(true);
		}
	}

	private void HideAllDusts()
	{
		for (int num = 0; num < dusts.Length; num += 1)
		{
			dusts[num].SetActive(false);
		}
	}

}
