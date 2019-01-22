using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incinerator : SingletonMonoBehaviour<Incinerator>
{
	private float speed = 8.0f;
	private Vector3 initPos;
	
	private void Awake ()
	{
		initPos = transform.position;
	}

	private void OnEnable()
	{
		ResetManager();
	}
	
	private void Update () {
		Move();
	}
	
	public void ResetManager()
	{
		transform.position = initPos;
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
	}
	
	public void Move ()
	{
		if (Input.GetKey("up"))
		{
			Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + speed * Time.deltaTime);
			this.transform.position = pos;
		}
		if (Input.GetKey("down"))
		{
			Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed * Time.deltaTime);
			this.transform.position = pos;
		}
		if (Input.GetKey("right"))
		{
			Vector3 pos = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
			this.transform.position = pos;
		}
		if (Input.GetKey("left"))
		{
			Vector3 pos = new Vector3(this.transform.position.x - speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
			this.transform.position = pos;
		}
	}
}
