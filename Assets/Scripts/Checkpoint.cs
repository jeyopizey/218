using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]Transform m_checkpoint;
	[SerializeField]GameObject m_object;
	[SerializeField]bool m_enableObject;
	[SerializeField]List<GameObject> m_objectsToEnable = new List<GameObject>(); 
	[SerializeField]AudioClip m_audio;
	AudioSource m_audioSource;

	private bool m_bCollected;

	void Start()
	{
		m_bCollected = false;
		m_audioSource = transform.GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider col) 
	{
		if (col.tag == "Player" && !m_bCollected) {
			CheckpointManager.Instance.CurrentCheckpoint = m_checkpoint;
			
			if (m_enableObject)
			{
				for (int i = 0; i < m_objectsToEnable.Count; i++)
				{
					m_objectsToEnable[i].SetActive(true);
				}
			}
			m_object.SetActive(false);
			m_audioSource.PlayOneShot(m_audio);
			m_bCollected = true;
		}
	}
}
