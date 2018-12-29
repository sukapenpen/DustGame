using System.Collections;
using UnityEngine;

public class DustManager : MonoBehaviour
{
	public GameObject DustPrefab;
	public int DustCount = 10;
	private GameObject[] dusts;
	private int dustCount;

	private void Awake()
	{
		dustCount = 0;
		dusts = new GameObject[DustCount];
		for (int i = 0; i < DustCount; i++)
		{
			dusts[i] = Instantiate(DustPrefab);
			dusts[i].SetActive(false);
		}
	}

	public void Start ()
	{
		StartCoroutine(AppearDust());
		
	}
	
	public void Update ()
	{
		
	}

	private IEnumerator AppearDust()
	{
		for (int i = 0; i < DustCount; i++)
		{
			dusts[i].SetActive(true);
			yield return new WaitForSeconds(2.0f);
		}
	}
}
