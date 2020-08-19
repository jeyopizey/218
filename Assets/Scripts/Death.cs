using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
	void OnTriggerEnter(Collider col) 
	{
		if (col.tag == "Player") {
			GameController.Instance.Respawn();
		}
	}
}
