using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	void OnTriggerEnter (Collider p_col)
	{
		if (p_col.tag == "Player") {
			LevelManager.Instance.LoadNextLevel();
		}
	}
}
