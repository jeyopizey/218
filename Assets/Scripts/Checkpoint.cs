using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]Transform m_checkpoint;
	[SerializeField]GameObject m_object;
	[SerializeField]bool m_enableObject;
	[SerializeField]List<GameObject> m_objectsToEnable = new List<GameObject>(); 

	void OnTriggerEnter(Collider col) 
	{
		if (col.tag == "Player") {
			CheckpointManager.Instance.CurrentCheckpoint = m_checkpoint;
			
			if (m_enableObject)
			{
				for (int i = 0; i < m_objectsToEnable.Count; i++)
				{
					m_objectsToEnable[i].SetActive(true);
				}
			}
			m_object.SetActive(false);
		}
	}
}
