using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoInstance<CheckpointManager>
{
    Transform m_currentCheckpoint;

	public Transform CurrentCheckpoint {
		get { return m_currentCheckpoint; }
		set { m_currentCheckpoint = value; }
	}
}
