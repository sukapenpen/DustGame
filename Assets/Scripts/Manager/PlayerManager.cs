using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingletonMonoBehaviour<PlayerManager>
{
	private GameObject dustBox;	
	private GameObject incinerator;

	public void Init()
	{
		dustBox = GameObject.FindWithTag("DustBox");
		incinerator = transform.Find("Incinerator").gameObject;
	}

	public void TitleSet()
	{
		StartPlayerObject(dustBox);
		StopPlayerObject(incinerator);
	}

	public void LoadSet()
	{
		StopPlayerObject(dustBox);
		StartPlayerObject(incinerator);
	}
	
	private void StartPlayerObject(GameObject _obj)
	{
		if (!_obj.activeSelf)
		{
			_obj.SetActive(true);
		}
	}
	
	private void StopPlayerObject(GameObject _obj)
	{
		if (_obj.activeSelf)
		{
			_obj.SetActive(false);
		}
	}
}
