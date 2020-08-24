using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoInstance<LevelManager>
{
	public void LoadNextLevel()
	{
		GameController.Instance.CurrentStage += 1;
		GameController.Instance.StartStage();
		SceneManager.LoadScene("Stage"+ (GameController.Instance.CurrentStage + 1) );
	}
}
