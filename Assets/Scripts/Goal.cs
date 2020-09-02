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
				// PlayerPrefs.SetInt("CurrentStage", 0);
				PlayerPrefs.SetInt("CurrentStage", 0);
				GameController.Instance.CurrentStage = 0;
			}
			else
			{
				HUDManager.Instance.PlayAnim("WhiteFadeIn");
				LevelManager.Instance.LoadNextLevel();
			}
		}
	}
}
