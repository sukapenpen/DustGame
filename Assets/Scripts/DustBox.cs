using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DustBox : MonoBehaviour
{
	private float speed = 2.0f;

	public void Start ()
	{
		
	}
	
	public void Update ()
	{
		if (Input.GetKey("up"))
		{
			transform.position += transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey("down"))
		{
			transform.position -= transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey("right"))
		{
			transform.position += transform.right * speed * Time.deltaTime;
		}
		if (Input.GetKey("left"))
		{
			transform.position -= transform.right * speed * Time.deltaTime;
		}
	}
}
