using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]Transform m_checkpoint;
	[SerializeField]GameObject m_object;

	void OnTriggerEnter(Collider col) 
	{
		if (col.tag == "Player") {
			CheckpointManager.Instance.CurrentCheckpoint = m_checkpoint;
			m_object.SetActive(false);
		}
	}
}
