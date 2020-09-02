using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoInstance<LevelManager>
{
	public void LoadNextLevel()
	{
		GameController.Instance.CurrentStage += 1;
		PlayerPrefs.SetInt("CurrentStage", GameController.Instance.CurrentStage);
		PlayerPrefs.Save();
		GameController.Instance.StartStage();
	}
}
