using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : SingletonMonoBehaviour<TextManager>
{
	private GameObject gUIDustCounter;
	private GameObject theNumberOfDusts;
	private int dustCounter;

	public void Init()
	{
		dustCounter = 0;
		gUIDustCounter = GameObject.FindWithTag("DustCounter");
		theNumberOfDusts = GameObject.FindWithTag("TheNumberOfDusts");
		gUIDustCounter.GetComponent<TextMesh>().text = dustCounter.ToString();
	}

	public void AddDustCounter()
	{
		dustCounter += 1;
		gUIDustCounter.GetComponent<TextMesh>().text = dustCounter.ToString();
	}
	
}
