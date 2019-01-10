using System.Collections;
using UnityEngine;

public class DustManager : SingletonMonoBehaviour<DustManager>
{
	public GameObject DustPrefab;
	private int dustCount;
	private GameObject[] dusts;

	private static DustManager instance;

	public void Init()
	{
		this.dustCount = 20;
		
	}

	public void Start ()
	{
		StartCoroutine(AppearDust());
	}
	
	public void Update ()
	{
		
	}

	private void CreateDust()
	{
		//for()
	}

	private IEnumerator AppearDust()
	{
		for (int i = 0; i < dustCount; i++)
		{
			dusts[i].SetActive(true);
			yield return new WaitForSeconds(2.0f);
		}
	}
}
