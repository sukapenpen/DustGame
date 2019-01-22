using UnityEngine;

public class DustBox : SingletonMonoBehaviour<DustBox>
{
	private Vector3 initPos;
	private float speed = 4.0f;

	private void Awake ()
	{
		initPos = new Vector3(0.0f, 1.0f, 0.3f);
	}

	private void OnEnable()
	{
		ResetManager();
	}

	public void ResetManager()
	{
		transform.position = initPos;
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
	}

}
