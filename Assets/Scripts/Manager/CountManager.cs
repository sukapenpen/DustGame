using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountManager
{
	private static CountManager instance;
	
	private int realTrashDustCounter;
	public int RealTrashDustCounter
	{
		get { return realTrashDustCounter; }
		private set { this.realTrashDustCounter = value; }
	}
	
	private int gameTrashDustCounter;
	public int GameTrashDustCounter
	{
		get { return gameTrashDustCounter; }
		private set { gameTrashDustCounter = value; }
	}
	
	private int playingFallingCounter;
	public int PlayingFallingCounter
	{
		get { return playingFallingCounter;}
		private set { playingFallingCounter = value; }
	}
	
	public static CountManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new CountManager();
			}

			return instance;
		}
        
		set
		{
			instance = value;
		}
	}
	
	public void Init ()
	{
		ResetManager();
	}
	
	public void ResetManager()
	{
		RealTrashReset();
		GameTrashDustCounter = 0;
		PlayingFallingCounter = 0;
	}

	public void RealTrashAdd()
	{
		RealTrashDustCounter += 1;
	}
	
	public void GameTrashAdd()
	{
		GameTrashDustCounter += 1;
	}
	
	public void PlayingFallingCounterAdd()
	{
		PlayingFallingCounter += 1;
	}

	public void RealTrashReset()
	{
		RealTrashDustCounter = 0;
	}
	
}
