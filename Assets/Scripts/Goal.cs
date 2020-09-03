using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	void OnTriggerEnter (Collider p_col)
	{
		if (p_col.tag == "Player") {

			if ( GameController.Instance.CurrentStage == 2 )
			{
				HUDManager.Instance.PlayAnim("GoodEnding");
				GameController.Instance.CurrentStage = 0;
				FirstPersonAIO.Instance.gameObject.SetActive(false);
				PlayerPrefs.SetInt("CurrentStage", GameController.Instance.CurrentStage);
				PlayerPrefs.Save();
			}
			else
			{
				HUDManager.Instance.PlayAnim("WhiteFadeIn");
				ShootController.Instance.PlayGoalAudio();
				LevelManager.Instance.LoadNextLevel();
			}
		}
	}

}
