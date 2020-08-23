using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoInstance<GameController>
{
	[SerializeField]GameObject m_player;
	[SerializeField]int m_currentStage;

	[SerializeField]List<string> m_stageScenes = new List<string>();
    
	public void StartStage()
	{
		m_player.transform.position = StartPointManager.Instance.StartPoint.position;
	}

	public void Respawn()
	{
		m_player.transform.position = CheckpointManager.Instance.CurrentCheckpoint.position;
	}

	public int CurrentStage
	{
		get { return m_currentStage; }
		set { m_currentStage = value; }
	}
}
