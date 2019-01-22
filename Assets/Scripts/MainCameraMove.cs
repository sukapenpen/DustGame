using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : SingletonMonoBehaviour<MainCameraMove>
{
	private GameObject dustBox;
	private int rotateSpeed = 10;
	private int moveSpeed = 10;
	private Vector3 aimPos;
	private Quaternion aimQuaternion;
	
	private void Awake()
	{
		dustBox = GameObject.FindWithTag("DustBox");
		aimPos = new Vector3(0, 18, 0);
		aimQuaternion = new Quaternion(90, 0, 0, 0);
	}

	private void Update()
	{
		var rotat = transform.rotation.x;
		if (rotat < 90)
		{
			transform.rotation = Quaternion.Euler(transform.rotation.x + rotateSpeed, 0, 0);
		}

	}

	private void RotateCmaeraAngle() {
		var angle = new Vector3(
			0,
			this.transform.position.y * rotateSpeed,
			0
		);
 
		transform.RotateAround(dustBox.transform.position, transform.right, angle.y);
	}

	private void MoveCamera()
	{
		 
	}

	private void MoveCameraPos()
	{
		var pos = transform.position;
		pos.y += moveSpeed * Time.deltaTime;
		transform.position = pos;
	}

}
