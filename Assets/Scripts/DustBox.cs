using UnityEngine;

public class DustBox : SingletonMonoBehaviour<DustBox>
{
	private Vector3 initPos;
	private float speed = 4.0f;
	private int realTrashDustCounter;
	public int RealTrashDustCounter
	{
		get { return realTrashDustCounter; }
		private set { realTrashDustCounter = value; }
	}
	private int gameTrashDustCounter;
	public int GameTrashDustCounter
	{
		get { return gameTrashDustCounter; }
		set { gameTrashDustCounter = value; }
	}

	public void Init ()
	{
		initPos = transform.position;
	}

	public void ResetManager()
	{
		transform.position = initPos;
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
		RealTrashDustCounter = 0;
		GameTrashDustCounter = 0;
	}

	public void AddRealDust()
	{
		RealTrashDustCounter += 1;
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
