using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoInstance<GameController>
{
	[SerializeField]GameObject m_player;

    public void Respawn()
	{
		m_player.transform.position = CheckpointManager.Instance.CurrentCheckpoint.position;
	}
}
